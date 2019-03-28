import React, { Component } from 'react'
import { Button, Form, Row, Container, Image, Col } from 'react-bootstrap/';
import { Link } from "react-router-dom";
import { connect } from 'react-redux';

import '../css/Login.css';
import { registerAction } from '../redux/action/SignUpAction';
class SignUp extends Component {

    constructor(props) {
        super(props);
        this.state = {
            firstName: '',
            lastName: '',
            email: '',
            username: '',
            password: '',
            confirmPassword: '',
            submitted: false
        }
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        event.preventDefault();

        this.setState({ submitted: true });
        const { firstName, lastName, email, username, password, confirmPassword } = this.state;
        const { dispatch } = this.props;
        if (firstName && lastName && username && password && email && confirmPassword && (confirmPassword === password)) {
            const user = {
                firstName: firstName,
                lastName: lastName,
                username: username,
                password: password,
                email: email
            }
            dispatch(registerAction(user));
        }
    }

    render() {
        const { firstName, lastName, email, username, password, confirmPassword, submitted } = this.state;
        return (
            <Container style={{ marginTop: "4%", padding: "30px", height: "auto", width: "500px", backgroundColor: "#FFF" }} >
                <Col>
                    <Row style={{ textAlign: 'center', height: '40px' }}>
                        <Col style={{ textAlign: 'center' }}>
                            <Image src="https://cdn0.iconfinder.com/data/icons/free-social-media-set/24/github-256.png" height="70px" />
                        </Col>
                        <br />
                    </Row>
                    <Row>
                        <Col style={{ textAlign: 'center' }}>
                            <h3 className='title' style={{ color: "#0074D9" }}>ENSON</h3>
                        </Col>
                    </Row>
                    <Row style={{ marginTop: 10 }}>
                        <Form onSubmit={this.handleSubmit}>
                            <Row>
                                <Col>
                                    <Form.Group controlId="firstName">
                                        <Form.Label>First Name</Form.Label>
                                        <Form.Control type="text" placeholder="" onChange={e => this.setState({ firstName: e.target.value })} />
                                        <Form.Text className="text-muted">
                                            {submitted && !firstName &&
                                                <div><p className='notice'>First Name is required</p></div>
                                            }
                                        </Form.Text>

                                    </Form.Group>
                                </Col>

                                <Col>
                                    <Form.Group controlId="lastName">
                                        <Form.Label>Last Name</Form.Label>
                                        <Form.Control type="text" placeholder="" onChange={e => this.setState({ lastName: e.target.value })} />
                                        <Form.Text className="text-muted">
                                            {submitted && !lastName &&
                                                <div><p className='notice'>Last Name is required</p></div>
                                            }
                                        </Form.Text>
                                    </Form.Group>
                                </Col>

                            </Row>
                            <Row>
                                <Col>
                                    <Form.Group controlId="formEmail" >
                                        <Form.Label>Email address</Form.Label >
                                        <Form.Control type="email" placeholder="" onChange={e => this.setState({ email: e.target.value })} />
                                        <Form.Text className="text-muted">
                                            {submitted && !email &&
                                                <div><p className='notice'>Email is required</p></div>
                                            }
                                        </Form.Text>
                                    </Form.Group>
                                    <Form.Group controlId="formUsername" >
                                        <Form.Label>Username</Form.Label >
                                        <Form.Control type="text" placeholder="" onChange={e => this.setState({ username: e.target.value })} />
                                        <Form.Text className="text-muted">
                                            {(submitted && !username) ?
                                                <div><p className='notice'>Username is required</p></div> : <div>You can use letters, numbers & periods</div>
                                            }
                                        </Form.Text>
                                    </Form.Group>

                                    <Row>
                                        <Col>
                                            <Form.Group controlId="formPassword" >
                                                <Form.Label>Password</Form.Label >
                                                <Form.Control type="password" suggested="password" onChange={e => this.setState({ password: e.target.value })} />
                                                <Form.Text className="text-muted">
                                                    {(submitted && !password) ?
                                                        <div><p className='notice'>Password is required</p></div> : <div>You can use letters, numbers & periods</div>
                                                    }
                                                </Form.Text>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="formConfirmPassword" >
                                                <Form.Label>Confirm Password</Form.Label >
                                                <Form.Control type="password" placeholder="" onChange={e => this.setState({ confirmPassword: e.target.value })} />
                                                <Form.Text className="text-muted">
                                                    {(submitted && !confirmPassword) ?
                                                        <div><p className='notice'>Comfirm password is required</p></div> : <div>You can use letters, numbers & periods</div>
                                                    }
                                                    {(submitted && confirmPassword && !(password === confirmPassword)) &&
                                                        <div><p className='notice'>Comfirm password is wrong</p></div>
                                                    }
                                                </Form.Text>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </Col>
                            </Row>

                            <Row>
                                <Col style={{ flex: 4 }}><Link to="/login"><Button variant="link">Already have an Account?</Button></Link></Col>
                                <Col style={{ flex: 1 }}><Button className="login" type="submit" style={{ width: '100px' }} variant="primary">Sign Up</Button></Col>
                            </Row>
                        </Form>
                    </Row>
                </Col>
            </Container>
        );
    }
}
function mapStateToProps(state) {
    const { registering } = state.registration;
    return {
        registering
    };
}

const connectedRegisterPage = connect(mapStateToProps)(SignUp);
export { connectedRegisterPage as SignUp };
