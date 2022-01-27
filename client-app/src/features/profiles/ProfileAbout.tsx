import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Button, Container, Divider, Grid, Header, Tab } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import * as Yup from 'yup';
import CustomTextInput from "../../app/common/form/CustomTextInput";
import CustomTextArea from "../../app/common/form/CustomTextArea";
import ProfileEditForm from "./ProfileEditForm";

export default observer(function ProfileAbout() {
    const { profileStore: { profile, isCurrentUser, updateProfile } } = useStore();
    const [editMode, setEditMode] = useState(false);

    function handleEditButtonClick() {
        setEditMode(!editMode);
    }

    return (
        <Tab.Pane>
            <Grid>
                <Grid.Column width={isCurrentUser ? 14 : 16}>
                    <Container text textAlign="justified">
                        {editMode 
                            ? <ProfileEditForm setEditMode={setEditMode} />
                            :
                            <>
                                <Grid.Row>
                                    <Header content={`About ${profile!.displayName}`} />
                                    <Divider />
                                </Grid.Row>
                                <Grid.Row>
                                    {profile?.bio
                                        ? <p>{profile.bio}</p>
                                        : <p style={{ color: 'lightgray' }}>Profile bio is empty :(</p>
                                    }
                                </Grid.Row>
                            </>
                        }
                    </Container>
                </Grid.Column>
                {isCurrentUser &&
                    <Grid.Column width={2}>
                        <Button.Group vertical >
                            <Button floated="right" color="grey" basic content={editMode ? "Cancel" : "Edit"} onClick={handleEditButtonClick} />
                        </Button.Group>
                    </Grid.Column>}
            </Grid>
        </Tab.Pane>
    )
})