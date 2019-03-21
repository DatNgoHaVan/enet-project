import React, { Component } from 'react';

import './App.css';
import Homepage from './components/Homepage';
import Login from './components/Login';
import 'bootstrap/dist/css/bootstrap.min.css'

class App extends Component {
  render() {
    return (
      <Login/>
    );
  }
}

export default App;
