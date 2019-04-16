import React, { Component } from "react";
import { Router, Route } from "react-router-dom";
import { connect } from "react-redux";

import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";

import { Login } from "./Login/Login";
import { SignUp } from "./SingUp/SignUp";
import { history } from "./redux/History";
import { alertClear } from "./redux/action/AlertAction";
import Homepage from "./Homepage/Homepage";
import { PrivateRoute } from "./components/PrivateRoute";
import { DashBoard } from "./DashBoard/DashBoard";
import { ViewUser } from "./ManageUser/ViewUser/ViewUser";
import BanUser from "./ManageUser/BanUser";

class App extends Component {
    constructor(props) {
        super(props);
        const { dispatch } = this.props;

        history.listen((location, action) => {
            dispatch(alertClear());
        });
    }

    render() {
        const { alert } = this.props;
        return (
            <div>
                {alert.message && (
                    <div className={`alert ${alert.type}`}>{alert.message}</div>
                )}
                <Router forceRefresh={true} history={history}>
                    <div>
                        <PrivateRoute exact path="/" component={Homepage} />
                        <Route path="/login" component={Login} />
                        <Route path="/admin" component={DashBoard} />
                        <Route path="/signup" component={SignUp} />
                        <Route
                            path="/admin/user/view/:id"
                            component={ViewUser}
                        />
                        <Route path="/admin/user/ban/:id" component={BanUser} />
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
