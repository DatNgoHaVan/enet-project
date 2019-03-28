import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import { connect } from 'react-redux';

import './App.css';
import Login from './components/Login';
import SignUp from './components/SignUp';
import 'bootstrap/dist/css/bootstrap.min.css'

class App extends Component {

  constructor(props) {
    super(props);
  }

  render() {
    const { alert } = this.props;
    console.log(alert);
    return (
      <div style={{backgroundColor : '#00cc99'}}>
            {alert.message &&
              <div className={`alert ${alert.type}`}>{alert.message}</div>
            }
            <Router>
              <div>
                <Route path="/login" component={Login} />
                <Route path="/" component={SignUp} />
              </div>
            </Router>
          </div>
    );
  }
}

function mapStateToProps(state) {
  const { alert } = state;
  return {
    alert
  };
}

const connectedApp = connect(mapStateToProps)(App);
export { connectedApp as App }; 
