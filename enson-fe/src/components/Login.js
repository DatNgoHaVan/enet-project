import React, { Component } from 'react';
import { Button, Form, Row, Container, Col } from 'react-bootstrap/';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";

import '../css/Login.css'
import SignUp from './SignUp';

class Login extends Component {
    render() {
        return (
            <Router>
                <Switch>
                    <Route path="/signup" component={SignUp}></Route>
                    <div>
                        <Container>
                            <Row>
                                <Col md={3}></Col>
                                <Col md={6} className="div">
                                    <div style={{ position: 'absolute', top: '20%' }}>
                                        <div className="form-control" style={{ height: '400px', borderStyle: 'inset', width: '450px' }}>
                                            <h3 className='title'>ENSON</h3>
                                            <h4 className='login-title'>Login</h4>
                                            <Form>
                                                <div>
                                                    <div>
                                                        <p style={{ marginLeft: '5%' }}>Username: </p>
                                                        <input type="text" cd className="form-control"
                                                            style={{
                                                                width: '90%',
                                                                marginLeft: '5%',
                                                                marginTop: '-10px',
                                                                marginBottom: '15px'
                                                            }}>
                                                        </input>
                                                    </div>
                                                    <div>
                                                        <p style={{ marginLeft: '5%' }}>Password: </p>
                                                        <input type="password" className="form-control"
                                                            style={{
                                                                width: '90%',
                                                                marginLeft: '5%',
                                                                marginTop: '-10px'
                                                            }}>
                                                        </input>
                                                    </div>
                                                    <div style={{ textAlign: 'right', marginRight: '5%' }}>
                                                        <a href='#'>Forgot your password?</a>
                                                    </div>
                                                    <div className="form-inline" style={{ marginTop: '7%' }}>
                                                        <Link to="/signup"><Button variant="link">Create account</Button></Link>
                                                        <div className="login-div">
                                                            <Button variant="primary" className='login' style={{ width: '100px' }}  > Login</Button>
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
                </Switch>
            </Router>
        );
    }
}

export default Login;
