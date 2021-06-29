import axios from 'axios';
import React, {useState} from 'react';
import {Form, FormGroup, Button, Container} from 'react-bootstrap';
import PropTypes from 'prop-types';
import './Login.css';

async function loginUser(credentials) {
    const response = await axios({
        method: 'post',
        url: 'https://localhost:44332/api/v1/login',
        headers: {},
        data: {
            username: credentials.username,
            password: credentials.password
        }
    }       
    )
    return response.data.token
    
}


export default function Login({ setToken }) {
    const [username, setUserName] = useState();
    const [password, setPassword] = useState();

    const handleSubmit = async e => {
        e.preventDefault();
        var token = await loginUser({
            username,
            password
        });
        console.log(token)
        setToken('Bearer ' + token);
    }

    return(
        <Container>
            <Form className = "login-form" onSubmit={handleSubmit}>
                <FormGroup controlId = "formBasicUsername">
                    <Form.Label>Login</Form.Label>
                    <Form.Control type = "text" placeholder = "Wpisz login" onChange={e => setUserName(e.target.value)}/>
                </FormGroup>
                <FormGroup controlId = "formBasicPassword">
                    <Form.Label>Hasło</Form.Label>
                    <Form.Control type = "password" placeholder = "Wpisz hasło" onChange={e => setPassword(e.target.value)}/>
                </FormGroup>
                <Button variant = "primary" type = "submit"
                className = "login-button">
                    Zaloguj
                </Button>
            </Form>
        </Container>       
    )
}

Login.propTypes = {
    setToken: PropTypes.func.isRequired
}
