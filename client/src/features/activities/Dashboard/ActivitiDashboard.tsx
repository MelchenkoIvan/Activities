import React from "react";
import { Grid } from "semantic-ui-react";
import { Activity } from "../../../app/Models/Activity";
import AcivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/activityForm";
import ActivityList from "./ActivitiList";

interface Props {
  activities: Activity[];
  selectedActivity: Activity | undefined;
  handleSelectedActivity: (id: string) => void;
  handleCancelSelectActivity: () => void;
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
  createOrEdite: (activity: Activity) => void;
  deleteActivity:(id:string) => void;
  submitting: boolean;
}
  
const ActivityDashboard = ({
  activities,
  selectedActivity,
  deleteActivity,
  handleSelectedActivity,
  handleCancelSelectActivity,
  editMode,
  openForm,
  closeForm,
  createOrEdite,
  submitting
}: Props) => {
  return (
    <>
      <Grid>
        <Grid.Column width="10">
          <ActivityList
            activities={activities}
            handleSelectedActivity={handleSelectedActivity}
            deleteActivity={deleteActivity}
            submitting={submitting}
          />
        </Grid.Column>
        <Grid.Column width="6">
          {selectedActivity && !editMode && (
            <AcivityDetails
              activity={selectedActivity}
              handleCancelSelectActivity={handleCancelSelectActivity}
              openForm={openForm}
            />
          )}
          {editMode && (
            <ActivityForm activity={selectedActivity} closeForm={closeForm} createOrEdite={createOrEdite} submitting = {submitting}/>
          )}
        </Grid.Column>
      </Grid>
    </>
  );
};
export default ActivityDashboard;
