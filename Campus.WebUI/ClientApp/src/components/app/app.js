import React, { Component } from 'react';
import Layout from '../layout';
import CampusService from '../../services/campus-service';
import ErrorBoundry from '../error-boundry/';
import { CampusServiceProvider } from '../campus-service-context';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import LectorsListPage from '../lectors/pages/lectors-list-page';
import LectorDetailPage from '../lectors/pages/lector-detail-page';
import EditLectorPage from '../lectors/pages/edit-lector-page';
import CreateLectorPage from '../lectors/pages/create-lector-page';

import GroupsListPage from '../groups/pages/groups-list-page';
import GroupDetailPage from '../groups/pages/group-detail-page';
import EditGroupPage from '../groups/pages/edit-group-page';
import CreateGroupPage from '../groups/pages/create-group-page';

import SpecialitiesListPage from '../specialities/pages/specialities-list-page';
import EditSpecialityPage from '../specialities/pages/edit-speciality-page';
import CreateSpecialityPage from '../specialities/pages/create-speciality-page';

import SubjectsListPage from '../subjects/pages/subjects-list-page';
import EditSubjectPage from '../subjects/pages/edit-subject-page';
import CreateSubjectPage from '../subjects/pages/create-subject-page';

import EditLectorSubjectPage from '../lector-subjects/pages/edit-lector-subject-page';
import CreateLectorSubjectPage from '../lector-subjects/pages/create-lector-subject-page';
import CreateLessonPage from '../lessons/pages/create-lesson-page';
import EditLessonPage from '../lessons/pages/edit-lesson-page';
import CreateAttendancePage from '../attendances/pages/create-attendance-page';


export default class App extends Component {
  static displayName = App.name;

  campusService = new CampusService();

  render() {
    return (
      <ErrorBoundry>
        <CampusServiceProvider value={this.campusService}>
          <Router>
          <Layout>
            <Switch>
            <Route exact path='/' component={() => { return <p>hello</p>; }} />

            <Route exact path ='/lectors' component = {LectorsListPage}/>
            <Route exact path ='/lectors/new' component = {CreateLectorPage}/>
            <Route exact path='/lectors/:id' component ={LectorDetailPage}/>            
            <Route exact path ='/lectors/edit/:id' component = {EditLectorPage}/> 

            <Route exact path ='/groups' component = {GroupsListPage}/>
            <Route exact path ='/groups/new' component = {CreateGroupPage}/>
            <Route exact path='/groups/:id' component ={GroupDetailPage}/>            
            <Route exact path ='/groups/edit/:id' component = {EditGroupPage}/> 

            <Route exact path ='/specialities' component = {SpecialitiesListPage}/>
            <Route exact path ='/specialities/new' component = {CreateSpecialityPage}/>                      
            <Route exact path ='/specialities/edit/:id' component = {EditSpecialityPage}/>

            <Route exact path ='/subjects' component = {SubjectsListPage}/>
            <Route exact path ='/subjects/new' component = {CreateSubjectPage}/>                     
            <Route exact path ='/subjects/edit/:id' component = {EditSubjectPage}/>
          
            <Route exact path ='/lectorsubject/new/:lectorId?' component = {CreateLectorSubjectPage}/>                     
            <Route exact path ='/lectorsubject/edit/:id' component = {EditLectorSubjectPage}/>

            <Route exact path='/lessons/new/:groupId?' component = {CreateLessonPage}/>
            <Route exact path='/lessons/edit/:id' component = {EditLessonPage}/>

            <Route exact path='/attendances/new' component= {CreateAttendancePage}/>
            </Switch>           
          </Layout>
          </Router>
        </CampusServiceProvider>
      </ErrorBoundry>
    );
  }
}
