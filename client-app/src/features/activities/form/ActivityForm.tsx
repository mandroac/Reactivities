import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Link, useHistory, useParams } from "react-router-dom";
import { Button, Header, Segment } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";
import { Formik, Form } from "formik";
import * as Yup from 'yup';
import CustomTextInput from "../../../app/common/form/CustomTextInput";
import CustomTextArea from "../../../app/common/form/CustomTextArea";
import CustomSelectInput from "../../../app/common/form/CustomSelectInput";
import { categoryOptions } from "../../../app/common/options/categoryOptions";
import CustomDateInput from "../../../app/common/form/CustomDateInput";
import { ActivityFormValues } from "../../../app/models/activity";
import { v4 as uuid } from 'uuid';


export default observer(function ActivityForm() {
    const history = useHistory();
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loadActivity, loadingInitial, setLoadingInitial } = activityStore;
    const { id } = useParams<{ id: string }>()
    const [activity, setActivity] = useState<ActivityFormValues>(new ActivityFormValues());

    const validationSchema = Yup.object({
        title: Yup.string().required(),
        description: Yup.string().required(),
        category: Yup.string().required(),
        date: Yup.string().required('Date is required').nullable(),
        city: Yup.string().required(),
        venue: Yup.string().required(),
    })

    useEffect(() => {
        id ? loadActivity(id).then(activity => setActivity(new ActivityFormValues(activity)))
            : setLoadingInitial(false);
    }, [id, loadActivity])

    function handleFormSubmit(activity: ActivityFormValues) {
        if (!activity.id) {
            let newActivity = {
                ...activity,
                id: uuid()
            }
            createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`));
        } else {
            updateActivity(activity).then(() => history.push(`/activities/${activity.id}`));
        }
    }

    if (loadingInitial) return <LoadingComponent content="Loading..." />

    return (
        <Segment clearing>
            <Header sub color="teal">
                Activity details
            </Header>
            <Formik
                enableReinitialize
                initialValues={activity}
                onSubmit={values => handleFormSubmit(values)}
                validationSchema={validationSchema} >
                {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                    <Form className="ui form" onSubmit={handleSubmit} autoComplete={'off'}>
                        <CustomTextInput placeholder={"Title"} name="title" />
                        <CustomTextArea placeholder={"Description"} name="description" rows={5} />
                        <CustomSelectInput placeholder={"Category"} name={"category"} options={categoryOptions} />
                        <CustomDateInput
                            placeholderText={"Date"}
                            name={"date"}
                            showTimeSelect
                            timeCaption="time"
                            dateFormat={'MMMM d, yyyy h:mm aa'} />
                        <Header sub color="teal">
                            Activity details
                        </Header>
                        <CustomTextInput placeholder={"City"} name={"city"} />
                        <CustomTextInput placeholder={"Venue"} name={"venue"} />
                        <Button 
                            disabled={isSubmitting || !dirty || !isValid}
                            loading={isSubmitting} floated="right" 
                            positive type={"submit"} content={"Submit"} />
                        <Button floated="right" type={"button"} content={"Cancel"} as={Link} to={'/activities'} />
                    </Form>
                )}
            </Formik>
        </Segment>
    )
})