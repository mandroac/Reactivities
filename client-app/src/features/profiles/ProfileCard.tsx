import { observer } from "mobx-react-lite";
import React from "react";
import { Link } from "react-router-dom";
import { Card, CardContent, CardDescription, CardHeader, Icon, Image } from "semantic-ui-react";
import { Profile } from "../../app/models/profile";
import FollowButton from "./FollowButton";

interface Props{
    profile: Profile
}

export default observer(function ProfileCard({profile}: Props){

    return(
        <Card as={Link} to={`/profiles/${profile.username}`} >
            <Image src={profile.image || '/assets/user.png'}  />
            <CardContent>
                <CardHeader content={profile.displayName} />
                <CardDescription content={profile.bio} />
            </CardContent>
            <CardContent extra>
                <Icon name="user" />
                {profile.followersCount} follower{profile.followersCount === 1 ? '' : 's' } 
            </CardContent>
            <FollowButton profile={profile} />
        </Card>
    )
})