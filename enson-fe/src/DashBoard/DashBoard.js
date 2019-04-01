import React, { Component } from 'react';

import './DashBoard.css';

class DashBoard extends Component{
    
    render(){
        return(
            <div className="container">
                <div className="form-inline header">
                    <p>ENSON</p>
                    <input className="form-control" type='text'></input>
                </div>
            </div>
        );
    }
}

export default DashBoard;