import React from 'react'
import {Form, FormGroup, Button, Container} from 'react-bootstrap'
import './Login.css'

export default class Login extends React.Component {



render() {
    return(
        <Container>
            <Form className = "login-form">
                <FormGroup controlId = "formBasicUsername">
                    <Form.Label>Login</Form.Label>
                    <Form.Control type = "text" placeholder = "Wpisz login" />
                </FormGroup>
                <FormGroup controlId = "formBasicPassword">
                    <Form.Label>Hasło</Form.Label>
                    <Form.Control type = "password" placeholder = "Wpisz hasło" />
                </FormGroup>
                <Button variant = "primary" type = "submit"
                className = "login-button">
                    Zaloguj
                </Button>
            </Form>
        </Container>       
    )
}
}