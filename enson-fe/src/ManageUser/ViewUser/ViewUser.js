import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { connect } from 'react-redux';

import { history } from '../../redux/History';
import { getUser } from './ViewUserAction';
import './ViewUser.css';

import avatar from '../../assets/images/25231.png';

class ViewUser extends Component {

    constructor(props) {
        super(props);
        this.handleClose = this.handleClose.bind(this);
    }

    componentDidMount() {
        const { id } = this.props.match.params;
        console.log(id);
        this.props.dispatch(getUser(id));
    }

    handleClose = (e) => {
        e.stopPropagation();
        this.props.history.goBack();
    }

    render() {
        const { user } = this.props;
        return (
            <div>
                {user &&
                    <div className="modalContainer container"
                        style={{
                            position: "fixed",
                            background: "#fff",
                            top: 25,
                            left: "10%",
                            right: "10%",
                            padding: 15,
                            border: "2px solid #444"
                        }}>
                        <div className="row">
                            <div className="col-lg-4 leftComponent">
                                <div style={{ textAlign: 'center' }}>
                                    <img className="avatarUser" src={avatar}></img>
                                    <p style={{ marginTop: '20px' }}>{user.userName} {user.roleId === 1 ?
                                        <button className="btn btn-sm btn-info" disabled>User</button> :
                                        <button className="btn btn-sm btn-danger" disabled>Admin</button>}</p>
                                </div>
                                <div className="row">
                                    <div className="col-sm-1"></div>
                                    <div className="col-sm-4">
                                        <p>First Name:</p>
                                    </div>
                                    <div className="col-sm-7">
                                        <p>{user.firstName}</p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-sm-1"></div>
                                    <div className="col-sm-4">
                                        <p>Last Name:</p>
                                    </div>
                                    <div className="col-sm-7">
                                        <p>{user.lastName}</p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-sm-1"></div>
                                    <div className="col-sm-4">
                                        <p>Email:</p>
                                    </div>
                                    <div className="col-sm-7">
                                        <p>{user.email}</p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-sm-1"></div>
                                    <div className="col-sm-4">
                                        <p>Phone:</p>
                                    </div>
                                    <div className="col-sm-7">
                                        <p>{user.phoneNumber}</p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-sm-1"></div>
                                    <div className="col-sm-4">
                                        <p>Adress:</p>
                                    </div>
                                    <div className="col-sm-7">
                                        <p>{user.address}</p>
                                    </div>
                                </div>
                                <div className="row">
                                    <div className="col-sm-1"></div>
                                    <div className="col-sm-4">
                                        <p>Last online:</p>
                                    </div>
                                    <div className="col-sm-7">
                                        <p>Now</p>
                                    </div>
                                </div>
                            </div>
                            <div className="col-lg-8">
                                <ul className="nav navContainer">
                                    <Link className="navLi active"><li >Activities</li></Link>
                                    <Link className="navLi"><li >Report</li></Link>
                                    <Link className="navLi"><li >Reported</li></Link>
                                </ul>
                            </div>
                        </div>
                        <div>
                            <button className="btn btn-md btn-danger" onClick={this.handleClose}>Close</button>
                        </div>
                    </div>}
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { user } = state.ViewUserReducer;
    return {
        user
    };
}

const connectedLoginPage = connect(mapStateToProps)(ViewUser);
export { connectedLoginPage as ViewUser };

