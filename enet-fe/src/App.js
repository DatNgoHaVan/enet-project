import React, { Component } from "react";
import { Router, Route } from "react-router-dom";
import { connect } from "react-redux";

import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";


import { SignUp } from "./pages/sign-up-page/sign-up";
import { history } from "./redux/history";
import { alertClear } from "./redux/action/alert-action";
import Homepage from "./pages/home-page/home-page";
import { PrivateRoute } from "./components/private-route";
import { ViewUser } from "./pages/manage-user-page/sections/view-user/view-user";
import BanUser from './pages/manage-user-page/sections/ban-user/ban-user';
import { Login } from "./pages/login-page/login";
import { DashBoard } from "./pages/dashboard-page/dashboard";

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
