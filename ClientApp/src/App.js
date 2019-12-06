import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import SignInSignUpSide from './components/SignInSignUpSide';

export default () => (
  <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/login' component={SignInSignUpSide} />
        <Route path='/register' component={SignInSignUpSide}/>
  </Layout>
);
