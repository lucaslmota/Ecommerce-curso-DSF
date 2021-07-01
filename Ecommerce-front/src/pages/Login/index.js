import React, { useState} from "react";
import { Container, Button, Card,Form } from "react-bootstrap";
import UserDataService from "../../Services/User/index";
import {TOKEN_KEY} from "../../Services/shared/api";

import "./style.css"

export default function Login({ history }) {

    const [user, setUser] = useState({ id: null, login: "", password: ""});
      
    const handleInputChange = event => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
    };
      
      
    const sendLogin = () => {
        var data = {
        login: user.login,
        password: user.password
    };
      
          UserDataService.login(data)
            .then(response => {
              localStorage.setItem(TOKEN_KEY, response.data?.result?.token);
              console.log(TOKEN_KEY+": "+localStorage.getItem(TOKEN_KEY));
              history.push("/categoria");
            })
            .catch(e => {
              console.log(e);
            });
        };
        

    return (

        <Container fluid className="Main">

            <Card className="text mx-auto " style={{ width: '25rem' }}>
                <Card.Body style={{ padding: '1.7rem' }}>
                    <Card.Title style={{ marginBottom: '2rem', textAlign: 'center' }} > <h6> Faça login em sua conta</h6></Card.Title>

                    <Form>
                      
                            <Form.Group >
                                <Form.Label>User </Form.Label>
                                <Form.Control 
                                    type="text"
                                    className="form-control"
                                    id="login"
                                    required
                                    value={user.login}
                                    onChange={handleInputChange}
                                    name="login"
                                />
                            </Form.Group>
                       
                      
                            <Form.Group >
                                <Form.Label> Senha </Form.Label>
                                <Form.Control 
                                    type="password"
                                    className="form-control"
                                    id="password"
                                    required
                                    value={user.password}
                                    onChange={handleInputChange}
                                    name="password"
                                />
                            </Form.Group>
                       
                        <Button id="Register" onClick={sendLogin} size="lg" block >Login</Button>
                    </Form>

                </Card.Body>
            </Card>

        </Container>
    )
}

