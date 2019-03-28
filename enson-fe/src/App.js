import React, { Component } from 'react';
import { Router, Route} from "react-router-dom";
import { connect } from 'react-redux';

import './App.css';
import {Login} from './components/Login';
import { SignUp } from './components/SignUp';
import 'bootstrap/dist/css/bootstrap.min.css'
import { history } from './redux/History';
import { alertClear } from './redux/action/AlertAction'
import Homepage from './components/Homepage';
import { PrivateRoute } from './components/PrivateRoute';

class App extends Component {

  constructor(props) {
    super(props);
    const { dispatch } = this.props;

    history.listen((location, action) => {
      dispatch(alertClear());
    })
  }

  render() {
    const { alert } = this.props;
    return (
      <div style={{ backgroundColor: '#00cc99' }}>
        {alert.message &&
          <div className={`alert ${alert.type}`}>{alert.message}</div>
        }
        <Router forceRefresh={true} history={history}>
          <div>
            <PrivateRoute exact path="/" component={Homepage} />
            <Route path="/login" component={Login} />
            <Route path="/signup" component={SignUp} />
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
