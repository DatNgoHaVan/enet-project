import React, { Component } from 'react';

import './DashBoard.css';
import search from '../assets/images/search.png'
import avatar from '../assets/images/25231.png'
import home from '../assets/images/home.png';
import user from '../assets/images/user.png';
import post from '../assets/images/post.png';
import report from '../assets/images/report.png';
import ManageUser from '../ManageUser/ManageUser';

class DashBoard extends Component {

    render() {
        return (
            <div >
                <div className="row rowContainer" >
                    <div className="col-lg-2" style={{ marginTop: '20px' }}>
                        <div className="nameProject">
                            <p style={{ width: 'auto', textAlign: 'center', fontSize: '28px' }}>ENSON</p>
                        </div>
                        <div className="bar">
                            <ul className="ul">
                                <li className="form-inline" style={{ textAlign: 'center',height : '45px', padding: '5px'}}>
                                    <img className="imageIcon" src={home}></img>
                                    <p className="titleMenu">Dashboard</p>
                                </li>
                                <li className="form-inline" style={{ textAlign: 'center' ,height : '45px',  padding: '5px' }}>
                                    <img className="imageIcon" src={user}></img>
                                    <p className="titleMenu">User</p>
                                </li>
                                <li className="form-inline" style={{ textAlign: 'center' ,height : '45px', padding: '5px' }}>
                                    <img className="imageIcon" src={post}></img>
                                    <p className="titleMenu">Post</p>
                                </li>
                                <li className="form-inline" style={{ textAlign: 'center',height : '45px', padding: '5px' }}>
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
                                            <p className="name">Anthony</p>
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <ManageUser />
                    </div>
                </div>
            </div>
        );
    }
}

export default DashBoard;