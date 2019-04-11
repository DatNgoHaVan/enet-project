import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

import { history } from '../../redux/History';
import './ViewUser.css';

import avatar from '../../assets/images/25231.png';

class ViewUser extends Component {

    constructor(props) {
        super(props);
        this.handleClose = this.handleClose.bind(this);
    }

    handleClose = (e) =>{
        e.stopPropagation();
        this.props.history.goBack();
    }

    render() {
        return (
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
                            <p style={{ marginTop: '20px' }}>Anthony <button className="btn btn-sm btn-danger" disabled>Admin</button></p>
                        </div>
                        <div className="row">
                            <div className="col-sm-2"></div>
                            <div className="col-sm-4">
                                <p>First Name:</p>
                            </div>
                            <div className="col-sm-6">
                                <p>Pham</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-sm-2"></div>
                            <div className="col-sm-4">
                                <p>Last Name:</p>
                            </div>
                            <div className="col-sm-6">
                                <p>Tai</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-sm-2"></div>
                            <div className="col-sm-4">
                                <p>Email:</p>
                            </div>
                            <div className="col-sm-6">
                                <p>Anthony@enclave.vn</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-sm-2"></div>
                            <div className="col-sm-4">
                                <p>Phone:</p>
                            </div>
                            <div className="col-sm-6">
                                <p>0975.452.***</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-sm-2"></div>
                            <div className="col-sm-4">
                                <p>Adress:</p>
                            </div>
                            <div className="col-sm-6">
                                <p>Hoa Khanh, Lien Chieu, Da Nang</p>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-sm-2"></div>
                            <div className="col-sm-4">
                                <p>Last online:</p>
                            </div>
                            <div className="col-sm-6">
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
            </div>
        );
    }
}

export default ViewUser;
