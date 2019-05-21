import React, { Component } from 'react';
import { history } from '../../../../redux/history';

class EditUser extends Component {

    constructor(props){
        super(props);
        this.logout = this.logout.bind(this);
    }
    
    logout(){
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        history.push('/');
    }

    render() {
        return (
            <div>
                <button onClick={this.logout}>Logout</button>
            </div>
        );
    }
}

export default EditUser;
