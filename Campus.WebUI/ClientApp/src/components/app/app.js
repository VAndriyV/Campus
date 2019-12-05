import React, { Component } from 'react';
import Layout from '../layout';
import CampusService from '../../services/campus-service';
import ErrorBoundry from '../error-boundry/';
import { CampusServiceProvider } from '../campus-service-context';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

import LectorsListPage from '../lectors/pages/lectors-list-page';
import LectorDetailPage from '../lectors/pages/lector-detail-page/lector-detail-page';
import EditLectorPage from '../lectors/pages/edit-lector-page/edit-lector-page';
import CreateLectorPage from '../lectors/pages/create-lector-page/create-lector-page';

import GroupsListPage from '../groups/pages/groups-list-page';
import GroupDetailPage from '../groups/pages/group-detail-page/group-detail-page';
import EditGroupPage from '../groups/pages/edit-group-page/edit-group-page';
import CreateGroupPage from '../groups/pages/create-group-page/create-group-page';

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

            </Switch>           
          </Layout>
          </Router>
        </CampusServiceProvider>
      </ErrorBoundry>
    );
  }
}
