import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from '../layout';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
            <Route exact path='/' component={() => { return <p>hello</p>; }} />       
      </Layout>
    );
  }
}
