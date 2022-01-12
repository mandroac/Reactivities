import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Link } from "react-router-dom";
import { Button, Item, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function ActivityList() {
    
    const {activityStore} = useStore();
    const {activitiesByDate, deleteActivity, loading} = activityStore;
    const[target, setTarget] = useState('');

    function handleActivityDelete(id: string) {
        setTarget(id);
        deleteActivity(id);
    }
    
    return (
        <Segment>
            <Item.Group divided>
                {activitiesByDate.map(activity => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as={'a'} >{activity.title}</Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Description>
                                <div>{activity.description}</div>
                                <div>{activity.city}, {activity.venue}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button floated="right" content="View" color="blue"
                                    as={Link} to={`/activities/${activity.id}`}
                                />
                                <Button 
                                    floated="right" content="Delete" color="red" name={activity.id}
                                    onClick={() => handleActivityDelete(activity.id)} 
                                    loading={loading && target === activity.id}
                                />
                                <Label basic content={activity.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})