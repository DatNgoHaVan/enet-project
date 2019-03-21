import React, { Component } from 'react';

import './App.css';
import Login from './components/Login';
import SignUp from './components/SignUp';
import 'bootstrap/dist/css/bootstrap.min.css'

class App extends Component {
  render() {
    return (
      <SignUp/>
    );
  }
}

export default App;
