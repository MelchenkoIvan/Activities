import React, { Fragment, useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import ActivityDashboard from "../../features/activities/Dashboard/ActivitiDashboard";
import { observer } from "mobx-react-lite";
import { Route, useLocation } from "react-router";
import HomePage from "../../features/home/HomePage";
import activityForm from "../../features/activities/form/activityForm";
import AcivityDetails from "../../features/activities/details/ActivityDetails";

function App() {
  const location = useLocation();

  return (
    <>
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Route exact path="/activities" component={ActivityDashboard} />
              <Route path="/activities/:id" component={AcivityDetails} />
              <Route
                key={location.key}
                path={["/createActivity", "/manage/:id"]}
                component={activityForm}
              />
            </Container>
          </>
        )}
      />
    </>
  );
}

export default observer(App);
