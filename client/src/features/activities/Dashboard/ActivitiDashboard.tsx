import { observer } from "mobx-react-lite";
import { Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import AcivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/activityForm";
import ActivityList from "./ActivitiList";



const ActivityDashboard = () => {
  const { activityStore } = useStore();
  const { selectedActivity, editMode } = activityStore;
  return (
    <>
      <Grid>
        <Grid.Column width="10">
          <ActivityList />
        </Grid.Column>
        <Grid.Column width="6">
          {selectedActivity && !editMode && <AcivityDetails />}
          {editMode && <ActivityForm />}
        </Grid.Column>
      </Grid>
    </>
  );
};
export default observer(ActivityDashboard);
