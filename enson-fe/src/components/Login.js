import React, { Component } from 'react';
import Button from 'react-bootstrap/Button';
import '../css/Login.css'

class Login extends Component {
    render() {
        return (
            <div style={{backgroundColor:'#00cc99'}}>
                <div className="container" >
                    <div className ="row">
                        <div className="col-md-3"></div>
                        <div className="col-md-6 div">
                            <div style={{position:'absolute', top:'20%'}}>
                                <div className="form-control" style={{height:'400px', borderStyle: 'inset', width:'450px'}}>
                                    <h3 className='title'>ENSON</h3>
                                    <h4 className='login-title'>Login</h4>
                                    <form>
                                        <div>
                                            <div>
                                                <p style={{marginLeft:'5%'}}>Username: </p>
                                                <input type="text" className="form-control" 
                                                style={{
                                                    width:'90%',
                                                    marginLeft:'5%',
                                                    marginTop:'-10px',
                                                    marginBottom:'15px'
                                                }}>
                                                </input>
                                            </div>
                                            <div>
                                            <p style={{marginLeft:'5%'}}>Password: </p>
                                            <input type="password" className="form-control" 
                                            style={{
                                                width:'90%',
                                                marginLeft:'5%',
                                                marginTop:'-10px'
                                            }}>
                                            </input>
                                            </div>
                                            <div style={{textAlign:'right', marginRight:'5%'}}>
                                                <a href='#'>Forgot your password?</a>
                                            </div>
                                            <div className="form-inline" style={{marginTop : '7%'}}>
                                                <a href='#' style={{marginLeft:'5%'}}>Create account</a>
                                                <div className="login">
                                                <Button variant="primary" style={{width :'100px'}}  >Login</Button>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div className="col-md-6"></div>
                    </div>
                </div>
            </div>
        );
    }
}

export default Login;
