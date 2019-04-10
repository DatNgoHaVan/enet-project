import React, { Component } from 'react';
import { connect } from 'react-redux';

import './ManageUserCss.css';
import { getAllUserAction } from './ManageUserAction';
import total from '../assets/images/total.png';
import up from '../assets/images/up.png';
import newUser from '../assets/images/newUser.png';
import onlineUser from '../assets/images/onlineUser.png';
import banUser from '../assets/images/banUser.png'
import PageNavigationTable from '../components/PageNavigationTable';

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
        this.props.dispatch(getAllUserAction());
        console.log("ahihihihi");
    }

    async componentDidUpdate(prevProps, prevState, snapshot) {
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
    }

    onPageChanged(value) {
        console.log(value);
        let dataPage = (value) * 10 - 10;
        let arr = this.state.data.slice();
        this.setState({ renderData: arr.splice(dataPage, 10) })
    }

    render() {
        const { data, renderData } = this.state;
        const { getAll, listUser } = this.props;
        console.log(renderData);
        console.log(listUser);
        return (
            <div>
                {listUser && <div className="container" style={{ width: '100%', maxWidth: '1270px', marginTop: '45px' }}>
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
                                    <td><button type="button" className="btn btn-success">New user</button></td>
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
                                {renderData.map((value, index) => (
                                    <tr>
                                        <td>{value.id}</td>
                                        <td>{value.name}</td>
                                        <td>{value.username}</td>
                                        <td>{value.email}</td>
                                        <td>{value.role}</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                ))}
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td>{!listUser ? '' : <PageNavigationTable totalRecords={listUser.length} onPageChanged={this.onPageChanged} />}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>}
            </div>
        );
    }
}

export default ManageUser;
function mapStateToProps(state) {
    const { getAll, listUser } = state.ManageUserReducer;
    return {
        getAll, listUser
    };
}

const connectedLoginPage = connect(mapStateToProps)(ManageUser);
export { connectedLoginPage as ManageUser }; 
