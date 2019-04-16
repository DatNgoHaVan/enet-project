import React, { Component } from 'react';
import { connect } from 'react-redux';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

import './ManageUserCss.css';
import { getAll } from '../../services/UserService';
import { getAllUserAction } from '../../redux/action/ManageUserAction';
import PageNavigationTable from '../../components/PageNavigationTable';

import total from '../assets/images/total.png';
import up from '../assets/images/up.png';
import newUser from '../assets/images/newUser.png';
import onlineUser from '../assets/images/onlineUser.png';
import banUser from '../assets/images/banUser.png'
import user from '../assets/images/user.png';
import edit from '../assets/images/edit.png';
import ban from '../assets/images/ban.png';

class ManageUser extends Component {

    constructor(props) {
        super(props);
        this.state = {
            page: 1,
            data: [],
            renderData: [],
        }


        this.onPageChanged = this.onPageChanged.bind(this);
    }

    async componentDidMount() {
        await getAll().then(async res => {
            if (res.ok) {
                await res.json().then(async list => {
                    await this.setState({ data: Array.from(list) });
                })
            }
        });
        const a = this.state.data.slice();
        await this.setState({ renderData: a.splice(0, 10) })
    }

    /*    async componentDidUpdate(prevProps, prevState, snapshot) {
            if (this.props.listUser !== prevProps.listUser) {
                this.props.dispatch(getAllUserAction());
                const { listUser } = this.props;
                console.log(listUser);
                if (listUser) {
                    await this.setState({ data: listUser });
                    const a = this.state.data.slice();
                    await this.setState({ renderData: a.splice(0, 10) })
                }
            }
        } */

    onPageChanged(value) {
        console.log(value);
        let dataPage = (value) * 10 - 10;
        let arr = this.state.data.slice();
        this.setState({ renderData: arr.splice(dataPage, 10) })
    }

    render() {
        const { data, renderData } = this.state;
        return (
            <div>
                {renderData && <div className="container" style={{ width: '100%', maxWidth: '1270px', marginTop: '45px' }}>
                    <div className="row">
                        <div className="col-lg-3">
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
                        <div className="col-lg-3">
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
                        <div className="col-lg-3">
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
                        <div className="col-lg-3">
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
                    <div style={{ marginTop: '40px' }}>
                        <table style={{ width: '100%' }}>
                            <thead>
                                <tr>
                                    <td className="tableNameContainer"><p className="tableName">User table</p></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Username</th>
                                    <th>Email</th>
                                    <th>Role</th>
                                    <th>Online</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {renderData.map((value) => (
                                    <tr key={value.userId}>
                                        <td>{value.userId}</td>
                                        <td>{value.firstName}  {value.lastName}</td>
                                        <td>{value.userName}</td>
                                        <td>{value.email}</td>
                                        <td>{value.roleId === 1 ? "User" : "Admin"}</td>
                                        <td></td>
                                        <td>
                                            <Link to={`/admin/user/view/${value.userId}`} className="linkRender"><button className="btn btn-sm btn-info btnRender" >View</button></Link>
                                            <Link to={`/admin/user/ban/${value.userId}`} className="linkRender"><button className="btn btn-sm btn-danger btnRender" >Ban</button></Link>
                                        </td>
                                    </tr>
                                ))}
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>{data.length === 0 ? '' : <PageNavigationTable totalRecords={data.length} onPageChanged={this.onPageChanged} />}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>}
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { getAll, listUser } = state.ManageUserReducer;
    return {
        getAll, listUser
    };
}

const connectedLoginPage = connect(mapStateToProps)(ManageUser);
export { connectedLoginPage as ManageUser }; 
