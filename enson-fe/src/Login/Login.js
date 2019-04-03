import React, { Component } from 'react';
import { Button, Form, Row, Container, Col } from 'react-bootstrap/';
import { Link } from "react-router-dom";
import { connect } from 'react-redux';

import './Login.css'
import { loginAction } from './LoginAction'

class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            submitted: false
        };
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(e) {
        e.preventDefault();

        this.setState({ submitted: true });
        const { username, password } = this.state;
        const { dispatch } = this.props;
        if (username && password) {
            dispatch(loginAction(username, password));
        }
    }

    render() {
        return (
            <div>
                <Container>
                    <Row>
                        <Col md={3}></Col>
                        <Col md={6} className="div">
                            <div style={{ position: 'absolute', top: '20%' }}>
                                <div className="form-control" style={{ height: '400px', borderStyle: 'inset', width: '450px' }}>
                                    <h3 className='title'>ENSON</h3>
                                    <h4 className='login-title'>Login</h4>
                                    <Form onSubmit={this.handleSubmit}>
                                        <div>
                                            <div>
                                                <p style={{ marginLeft: '5%' }}>Username: </p>
                                                <input type="text" className="form-control" onChange={e => this.setState({ username: e.target.value })}
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
                                                <input type="password" className="form-control" onChange={e => this.setState({ password: e.target.value })}
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
                                                    <Button variant="primary" type="submit" className='login' style={{ width: '100px' }}  > Login</Button>
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

function mapStateToProps(state) {
    const { loggingIn } = state.LoginReducer;
    return {
        loggingIn
    };
}

const connectedLoginPage = connect(mapStateToProps)(Login);
export { connectedLoginPage as Login }; 
