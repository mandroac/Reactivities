import { observer } from "mobx-react-lite";
import React, { SyntheticEvent, useState } from "react";
import { Card, Header, Tab, Image, Grid, Button, ButtonGroup } from "semantic-ui-react";
import PhotoUploadWidget from "../../app/common/imageUpload/PhotoUploadWidget";
import { Photo, Profile } from "../../app/models/profile";
import { useStore } from "../../app/stores/store";

interface Props {
    profile: Profile;
}

export default observer(function ProfilePhotos({ profile }: Props) {
    const { profileStore: { isCurrentUser, uploadPhoto, uploading, 
        loading, setMainPhoto, deletePhoto } } = useStore();
    const [addPhotoMode, setAddPhotoMode] = useState(false);
    const [target, setTarget] = useState('');

    function handleSetMainPhoto(photo: Photo, e: SyntheticEvent<HTMLButtonElement>){
        setTarget(e.currentTarget.name);
        setMainPhoto(photo);
    }

    function handleDeletePhoto(photo: Photo){
        setTarget(photo.id);
        deletePhoto(photo);
    }

    function handlePhotoUpload(file: Blob){
        uploadPhoto(file).then(() => setAddPhotoMode(false));
    }

    return (
        <Tab.Pane>
            <Grid>
                <Grid.Column width={16}>
                    <Header floated="left" icon={'image'} content={'Photos'} />
                    {isCurrentUser && (
                        <Button floated="right" basic content={addPhotoMode ? 'Cancel' : 'AddPhoto'}
                            onClick={() => setAddPhotoMode(!addPhotoMode)}
                        />
                    )}
                </Grid.Column>
                <Grid.Column width={16}>
                    {addPhotoMode ? (
                        <PhotoUploadWidget uploadPhoto={handlePhotoUpload} loading={uploading} />
                    ) : (
                        <Card.Group itemsPerRow={5}>
                            {profile.photos?.map(photo => (
                                <Card key={photo.id}>
                                    <Image src={photo.url} />
                                    {isCurrentUser && (
                                        <ButtonGroup fluid widths={2}>
                                            <Button 
                                                basic 
                                                color="green" 
                                                content="Main"
                                                name={'main' + photo.id} 
                                                disabled={photo.isMain}
                                                loading = {target === 'main' + photo.id && loading}
                                                onClick = {e => handleSetMainPhoto(photo, e)}
                                            />
                                            <Button 
                                                basic 
                                                name={photo.id}
                                                color="red" 
                                                icon="trash" 
                                                loading = {target === photo.id && loading}
                                                onClick={() => handleDeletePhoto(photo)}
                                                disabled={photo.isMain}
                                                />

                                        </ButtonGroup>
                                    )}
                                </Card>
                            ))}
                        </Card.Group>
                    )}
                </Grid.Column>
            </Grid>
        </Tab.Pane>
    )
})