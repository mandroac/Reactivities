import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid, GridColumn } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import ProfileContent from "./ProfileContent";
import ProfileHeader from "./ProfileHeader";

export default observer(function ProfilePage() {
    const { username } = useParams<{ username: string }>();
    const { profileStore } = useStore();
    const { loadingProfile, loadProfile, profile, setActiveTab } = profileStore;

    useEffect(() => {
        loadProfile(username);
        return () => setActiveTab(0);
    }, [loadProfile, username, setActiveTab]);

    if (loadingProfile) <LoadingComponent content="Loading profile..." />
    return (
        <Grid>
            <GridColumn>
                {profile &&
                    <>
                        <ProfileHeader profile={profile} />
                        <ProfileContent profile={profile} />
                    </>}
            </GridColumn>
        </Grid>
    )
})