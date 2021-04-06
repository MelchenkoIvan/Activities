import React, { Fragment, useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import { Activity } from "../Models/Activity";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/Dashboard/ActivitiDashboard";
import { v4 as uuid } from "uuid";
import agent from "../api/agent";
import LoadingComponent from "./LoadingComponent";

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<
    Activity | undefined
  >(undefined);
  const [editMode, setEditMode] = useState(false);
  const [loading, setLoading] = useState(true);
  const[submitting , setSubmiting] = useState(false);

  useEffect(() => {
    agent.Activities.list().then(response => {
      let activities: Activity[] = [];
      response.forEach(activity => {
        activity.date = activity.date.split('T')[0];
        activities.push(activity);
      })
      setActivities(activities);
      setLoading(false);
    });
  }, []);

  const handleSelectedActivity = (id: string) => {
    setSelectedActivity(activities.find((x) => x.id === id));
  };
  const handleCancelSelectActivity = () => {
    setSelectedActivity(undefined);
  };

  const handleFormOpen = (id?: string) => {
    id ? handleSelectedActivity(id) : handleCancelSelectActivity();
    setEditMode(true);
  };

  const handleFormClose = (id?: string) => {
    setEditMode(false);
  };

  const handleCreateOrEditActivity = (activity: Activity) => {
    setSubmiting(true);
    if(activity.id){
      agent.Activities.update(activity).then(()=>{
        setActivities([ ...activities.filter((x) => x.id !== activity.id), activity])
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmiting(false);
      })
    }else{
      activity.id = uuid();
      agent.Activities.create(activity).then(()=>{
          setActivities([...activities, activity])
          setSelectedActivity(activity);
          setEditMode(false);
          setSubmiting(false);
      })
    }
  };

  function handleDeleteActivity(id: string) {
    setSubmiting(true);
    agent.Activities.delete(id).then(()=>{
      setActivities([...activities.filter((x) => x.id !== id)]);
      setSubmiting(false);
    })
    
  }

  if(loading) return<LoadingComponent content="Loading app"/>

  return (
    <Fragment>
      <NavBar openForm={handleFormOpen} />
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashboard
          activities={activities}
          selectedActivity={selectedActivity}
          handleSelectedActivity={handleSelectedActivity}
          handleCancelSelectActivity={handleCancelSelectActivity}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEdite={handleCreateOrEditActivity}
          deleteActivity={handleDeleteActivity}
          submitting={submitting}
        />
      </Container>
    </Fragment>
  );
}

export default App;
