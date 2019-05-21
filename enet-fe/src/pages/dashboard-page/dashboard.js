import React, { Component } from 'react';
import { connect } from 'react-redux';

import './dashboard.css';
import { history } from '../../redux/history';
import { getUser } from '../../redux/action/view-user-action';

import search from '../../assets/images/search.png'
import avatar from '../../assets/images/25231.png'
import home from '../../assets/images/home.png';
import userImg from '../../assets/images/user.png';
import post from '../../assets/images/post.png';
import report from '../../assets/images/report.png';
import pass from '../../assets/images/pass.png';
import logout from '../../assets/images/exit.png';

import { ManageUser } from '../manage-user-page/manage-user';
import { parseJwt } from '../../components/comment';

class DashBoard extends Component {

    constructor(props) {
        super(props);
        this.handleLogout = this.handleLogout.bind(this);
        this.handleClickTittle = this.handleClickTittle.bind(this);
    }

    handleLogout() {
        localStorage.removeItem('token');
        localStorage.removeItem('tokenB');
        localStorage.removeItem('role');
        history.push('/');
    }

    handleClickTittle() {
        history.push('/');
    }

    componentDidMount() {
        const token = localStorage.getItem('tokenB');
        this.props.dispatch(getUser(parseJwt(token).nameid));
    }

    render() {
        const { user } = this.props;
        return (
            <div >
                {user &&
                    <div className="row rowContainer" >
                        <div className="col-lg-2" style={{ marginTop: '20px' }}>
                            <div className="nameProject">
                                <p style={{ width: 'auto', textAlign: 'center', fontSize: '28px' }}><a onClick={this.handleClickTittle}>ENET</a></p>
                            </div>
                            <div style={{ marginLeft: '10px' }}>
                                <div className="form-inline">
                                    <img className="avatarBar" src={avatar} />
                                    <div style={{ marginLeft: '15px' }}>
                                        <p style={{ marginTop: '15px', marginLeft: '16px', height: '10px' }}>{user.userName}</p>
                                        <div className="form-inline naviContainer">
                                            <button className="btn bt" ><img className="naviBtn" src={userImg} /></button>
                                            <button className="btn bt"><img className="naviBtn" src={pass} /></button>
                                            <button className="btn bt" onClick={this.handleLogout}><img className="naviBtn" src={logout} /></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div className="bar">
                                <ul className="ul">
                                    <li className="form-inline" style={{ textAlign: 'center', height: '45px' }}>
                                        <img className="imageIcon" src={home}></img>
                                        <p className="titleMenu">Dashboard</p>
                                    </li>
                                    <li className="form-inline" style={{ textAlign: 'center', height: '45px' }}>
                                        <img className="imageIcon" src={userImg}></img>
                                        <p className="titleMenu">User</p>
                                    </li>
                                    <li className="form-inline" style={{ textAlign: 'center', height: '45px' }}>
                                        <img className="imageIcon" src={post}></img>
                                        <p className="titleMenu">Post</p>
                                    </li>
                                    <li className="form-inline" style={{ textAlign: 'center', height: '45px' }}>
                                        <img className="imageIcon" src={report}></img>
                                        <p className="titleMenu">Report</p>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div className="col-lg-10 linear">
                            <div className="container" style={{ marginTop: '30px', margin: '10px', maxWidth: '1270px' }}>
                                <div className="row">
                                    <div className="col-lg-3">
                                        <p className="titleDash">Dashboard</p>
                                    </div>
                                    <div className="col-lg-4" ></div>
                                    <div className="col-lg-5" >
                                        <div className="form-inline">
                                            <div className="form-inline searchContainer">
                                                <img className="searchImage" src={search}></img>
                                                <input placeholder="Search" type="text" className="inputValue"></input>
                                            </div>
                                            <button className="avatarBtn form-inline">
                                                <img className="avatar" src={avatar}></img>
                                                <p className="name">{user.userName}</p>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <ManageUser />
                        </div>
                    </div>
                }
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

const connectedLoginPage = connect(mapStateToProps)(DashBoard);
export { connectedLoginPage as DashBoard };
