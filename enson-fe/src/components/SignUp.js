import React, { Component } from 'react'
import { Button, Form, Row, Container, Image, Col } from 'react-bootstrap/';
import '../css/Login.css'
class SignUp extends Component {
    render() {
        return (
            <Container style={{ marginTop: "4%", padding: "30px", height: "auto", width: "500px", backgroundColor: "#FFF" }} >
                <Col>
                    <Row style = {{textAlign:'center', height:'40px'}}>
                        <Col style={{textAlign :'center'}}>
                            <Image src="https://cdn0.iconfinder.com/data/icons/free-social-media-set/24/github-256.png" height="70px" />
                        </Col>
                        <br/>
                    </Row>
                    <Row>
                        <Col style={{textAlign:'center'}}>
                            <h3 className='title' style={{ color: "#0074D9" }}>ENSON</h3>
                        </Col>
                    </Row>
                    <Row style={{ marginTop: 20 }}>
                        <Form>
                            <Row>
                                <Col>
                                    <Form.Group controlId="firstName">
                                        <Form.Label>First Name</Form.Label>
                                        <Form.Control type="text" placeholder="" />
                                        <Form.Text className="text-muted">
                                            
                                        </Form.Text>
                                    </Form.Group>
                                </Col>

                                <Col>
                                    <Form.Group controlId="lastName">
                                        <Form.Label>Last Name</Form.Label>
                                        <Form.Control type="text" placeholder="" />
                                        <Form.Text className="text-muted">
                                        </Form.Text>
                                    </Form.Group>
                                </Col>

                            </Row>
                            <Row>
                                <Col>
                                    <Form.Group controlId="formEmail" >
                                        <Form.Label>Email address</Form.Label >
                                        <Form.Control type="email" placeholder="" />
                                        <Form.Text className="text-muted">
                                        </Form.Text>
                                    </Form.Group>
                                    <Form.Group controlId="formUsername" >
                                        <Form.Label>Username</Form.Label >
                                        <Form.Control type="text" placeholder="" />
                                        <Form.Text className="text-muted">
                                            You can use letters, numbers & periods
                                        </Form.Text>
                                    </Form.Group>

                                    <Row>
                                        <Col>
                                            <Form.Group controlId="formPassword" >
                                                <Form.Label>Password</Form.Label >
                                                <Form.Control type="password" placeholder="" />
                                                <Form.Text className="text-muted">
                                                    You can use letters, numbers & periods
                                                 </Form.Text>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="formConfirmPassword" >
                                                <Form.Label>Confirm Password</Form.Label >
                                                <Form.Control type="password" placeholder="" />
                                                <Form.Text className="text-muted">
                                                    You can use letters, numbers & periods
                                                 </Form.Text>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                </Col>
                            </Row>
                            <Row>
                                <Col style={{flex:4}}><Button variant="link">Already have an Account?</Button></Col>
                                <Col style={{flex:1}}><Button className="login" style={{width:'100px'}} variant="primary" controlId="btnSignUp">Sign Up</Button></Col>
                            </Row>

                        </Form>
                    </Row>

                </Col>
            </Container>
        );
    }
}
export default SignUp;
