import React, { Component } from 'react';
import { Button, Form, Row, Container, Image, Col } from 'react-bootstrap/';
import '../css/Login.css'

class Login extends Component {
    render() {
        return (
            <div style={{backgroundColor:'#00cc99'}}>
                <Container>
                    <Row>
                        <Col md={3}></Col>
                        <Col md={6} className="div">
                            <div style={{position:'absolute', top:'20%'}}>
                                <div className="form-control" style={{height:'400px', borderStyle: 'inset', width:'450px'}}>
                                    <h3 className='title'>ENSON</h3>
                                    <h4 className='login-title'>Login</h4>
                                    <Form>
                                        <div>
                                            <div>
                                                <p style={{marginLeft:'5%'}}>Username: </p>
                                                <input type="text" cd className="form-control" 
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
                                                <div className="login-div">
                                                <Button variant="primary" className='login' style={{width :'100px'}}  > Login</Button>
                                                </div>
                                            </div>
                                        </div>
                                    </Form>
                                </div>
                            </div>
                        </Col>
                        <Col md={3}></Col>
                    </Row>
                </Container>
            </div>
        );
    }
}

export default Login;
