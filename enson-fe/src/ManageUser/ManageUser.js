import React, { Component } from 'react';

import './ManageUserCss.css';
import total from '../assets/images/total.png';
import up from '../assets/images/up.png';
import newUser from '../assets/images/newUser.png';
import onlineUser from '../assets/images/onlineUser.png';
import banUser from '../assets/images/banUser.png'

class ManageUser extends Component {

    render() {
        return (
            <div class="container" style={{ width: '100%', maxWidth: '1270px', marginTop : '45px' }}>
                <div class="row">
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>Total user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={total}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>New user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={newUser}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>Online user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={onlineUser}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>Ban user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={banUser}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style={{marginTop : '40px'}}>
                    <table style={{width : '100%'}}>
                        <tr>
                            <td className="tableNameContainer"><p className="tableName">User table</p></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td><button type="button" className="btn btn-success">New user</button></td>
                        </tr>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Username</th>
                            <th>Email</th>
                            <th>Role</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                        <tr>
                            <td>01</td>
                            <td>Anthony</td>
                            <td>Anthony</td>
                            <td>Anthony@enclave.vn</td>
                            <td>Admin</td>
                            <td>Online</td>
                        </tr>
                        <tr>
                            <td>02</td>
                            <td>Anthony</td>
                            <td>Anthony</td>
                            <td>Anthony@enclave.vn</td>
                            <td>Admin</td>
                            <td>Online</td>
                        </tr>
                        <tr>
                            <td>03</td>
                            <td>Anthony</td>
                            <td>Anthony</td>
                            <td>Anthony@enclave.vn</td>
                            <td>Admin</td>
                            <td>Online</td>
                        </tr>
                        <tr>
                            <td>04</td>
                            <td>Anthony</td>
                            <td>Anthony</td>
                            <td>Anthony@enclave.vn</td>
                            <td>Admin</td>
                            <td>Online</td>
                        </tr>
                    </table>
                </div>
            </div>
        );
    }
}

export default ManageUser;