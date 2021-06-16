import { Container, Row, Col } from 'react-bootstrap';
import './Phonebook.css'

function Phonebook() {
    return(
        <Container fluid="md">
            <Row>
                <Col>Centrala Telefoniczna</Col>
                <Col>4</Col>
            </Row>
            <Row>
                <Col></Col>
            </Row>
        </Container>
    )
}

export default Phonebook;
