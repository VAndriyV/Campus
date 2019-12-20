import React, { Component } from 'react';
import Layout from '../layout';
import CampusService from '../../services/campus-service';
import UserService from '../../services/user-service';
import ErrorBoundry from '../error-boundry/';
import { CampusServiceProvider } from '../campus-service-context';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { AuthenticatedRoute, UnauthenticatedRoute } from '../restricted-route';
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
import LoginPage from '../user/pages/login-page';
import HomePage from '../home-page';
import NotFoundPage from '../error-pages/not-found-page';


export default class App extends Component {

  constructor(props){
    super(props);

    this.updateCurrentUser = this.updateCurrentUser.bind(this);
  }

  campusService = new CampusService();
  userService = new UserService((user)=>this.updateCurrentUser(user));

  state = {
    currentUser: this.userService.currentUser()
  }

  updateCurrentUser(user){
    this.setState({
      currentUser: user
    });
  };

  static displayName = App.name;

  render() {
    const { currentUser } = this.state;      
    return (
      <Router>
      <ErrorBoundry>
        <CampusServiceProvider value={this.campusService}>         
            <Layout user={currentUser} userService={this.userService}>
              <Switch>
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin', 'Lector']} exact  path="/" component={HomePage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lectors' component={LectorsListPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lectors/new' component={CreateLectorPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lectors/:id' component={LectorDetailPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lectors/edit/:id' component={EditLectorPage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/groups' component={GroupsListPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/groups/new' component={CreateGroupPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/groups/:id' component={GroupDetailPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/groups/edit/:id' component={EditGroupPage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/specialities' component={SpecialitiesListPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/specialities/new' component={CreateSpecialityPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/specialities/edit/:id' component={EditSpecialityPage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/subjects' component={SubjectsListPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin']} exact path='/subjects/new' component={CreateSubjectPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/subjects/edit/:id' component={EditSubjectPage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lectorsubject/new/:lectorId?' component={CreateLectorSubjectPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lectorsubject/edit/:id' component={EditLectorSubjectPage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lessons/new/:groupId?' component={CreateLessonPage} />
                <AuthenticatedRoute user={currentUser} requiredRoles={['Admin', 'SuperAdmin']} exact path='/lessons/edit/:id' component={EditLessonPage} />

                <AuthenticatedRoute user={currentUser} requiredRoles={['Lector', 'Admin', 'SuperAdmin']} exact path='/attendances/new' component={CreateAttendancePage} />

                <UnauthenticatedRoute user={currentUser} path='/login' userService={this.userService} component={LoginPage} />

                <Route render={(props)=> <NotFoundPage displayHomeLink={false} {...props} />} />
              </Switch>
            </Layout>          
        </CampusServiceProvider>
      </ErrorBoundry>
      </Router>
    );
  }
}
