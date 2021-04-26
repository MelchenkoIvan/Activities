import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { useParams } from "react-router";
import { Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import ProfileContent from "./ProfileContent";
import ProfilrHeader from "./ProfileHeader";

const ProfilePage = () => {
  const { username } = useParams<{ username: string }>();
  const { profileStore } = useStore();
  const { loadingProfile, loadProfile, profile,setActiveTab } = profileStore;

  useEffect(() => {
    loadProfile(username);
    return() => {
      setActiveTab(0);
    }
  }, [loadProfile, username]);

  if (loadingProfile) return <LoadingComponent content="Loading Profile ..." />;

  return (
    <Grid>
      <Grid.Column width={16}>
        {profile && (
          <>
            <ProfilrHeader profile={profile} />{" "}
            <ProfileContent profile={profile} />
          </>
        )}
      </Grid.Column>
    </Grid>
  );
};

export default observer(ProfilePage);
