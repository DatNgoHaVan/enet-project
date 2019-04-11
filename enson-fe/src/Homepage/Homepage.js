import React, { Component } from 'react';
import { history } from '../redux/History';

class Homepage extends Component {

    constructor(props){
        super(props);
        this.logout = this.logout.bind(this);
    }
    
    logout(){
        localStorage.removeItem('token');
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

export default Homepage;