import React, { Component } from 'react';
import Layout from '../layout';
import CampusService from '../../services/campus-service';
import ErrorBoundry from '../error-boundry/';
import { CampusServiceProvider } from '../campus-service-context';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import LectorsListPage from '../lectors/pages/lectors-list-page';


export default class App extends Component {
  static displayName = App.name;

  campusService = new CampusService();

  render() {
    return (
      <ErrorBoundry>
        <CampusServiceProvider value={this.campusService}>
          <Router>
          <Layout>
            <Route exact path='/' component={() => { return <p>hello</p>; }} />
            <Route exact path ='/lectors' component = {LectorsListPage}/>
          </Layout>
          </Router>
        </CampusServiceProvider>
      </ErrorBoundry>
    );
  }
}
