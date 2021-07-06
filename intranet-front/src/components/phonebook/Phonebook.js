import React, { useEffect, useState } from 'react';
import { Table, Button, Modal, Form } from 'react-bootstrap';
import './Phonebook.css';

export default function Phonebook() { 
    
    const [phones, setPhones] = useState([]);
    const [show, setShow] = useState(false);

    const [phoneNumber, setPhoneNumber] = useState();
    const [phoneName, setPhoneName] = useState();

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const token = sessionStorage.getItem('token');

    async function addPhone(details) {
        const response = await fetch ('https://localhost:44332/api/v1/phones',{
            method: 'post',
            headers: {
                Authorization: token,
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify({
                name: details.phoneName,
                number: details.phoneNumber
            })
        })
        console.log(response);
        return response
    }

    useEffect(() => {
        fetch('https://localhost:44332/api/v1/phones',
        {
            method: 'GET',
            headers: {
                'Access-Control-Allow-Origin': '*',
            }
        })
        .then(res => res.json())
        .then(response => {
            setPhones(response);
        })
        .catch(error => console.log(error));
    }, [])

    async function refreshPhones() {
        fetch('https://localhost:44332/api/v1/phones',
        {
            method: 'GET',
        })
        .then(res => res.json())
        .then(response => {
            setPhones(response);
        })
        .catch(error => console.log(error));
    }

    async function deletePhone(id) {
        fetch('https://localhost:44332/api/v1/phones/' + id,
        {
            method: 'Delete',
            headers:{
                Authorization: token
            }
        });
        await refreshPhones();
    }

    const handleSubmit = async e => {
        e.preventDefault();
        await addPhone({
            phoneName,
            phoneNumber
        });
        handleClose();
        await refreshPhones();
    }

    return (
        <div className="Main">
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Nazwa</th>
                        <th>Numer</th>
                    </tr>
                </thead>

                {phones.map(c => (
                <tbody key={c.id}>
                    <tr>
                        <td>{c.name}</td>
                        <td>{c.number}</td>
                        <td><Button className="editors" size="sm" variant="danger" onClick={() => deletePhone(c.id)}>Usuń</Button></td>
                        <td><Button className="editors" size="sm" variant="success">Edytuj</Button></td>                        
                    </tr>
                </tbody>
                ))}
            </Table>
            <div>
                <Button className="editors" variant="primary" onClick={handleShow}>Dodaj</Button>
            </div>
            <div>
                <Modal show={show} onHide={handleClose} animation={false}>
                    <Modal.Header closeButton>
                        <Modal.Title>Dodaj numer telefonu</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form onSubmit={handleSubmit}>
                            <Form.Group controlId = "formBasicName">
                                <Form.Label>Nazwa</Form.Label>
                                <Form.Control type="text" placeholder="Nazwa numeru" onChange={e => setPhoneName(e.target.value)}/>                                
                            </Form.Group>
                            <Form.Group controlId = "formBasicNumber">
                                <Form.Label>Numer</Form.Label>
                                <Form.Control type="number" placeholder="Numer telefonu" onChange={e => setPhoneNumber(e.target.value)}/>
                            </Form.Group>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="primary" onClick={handleSubmit}>Zapisz</Button>
                        <Button variant="secondary" onClick={handleClose}>Zamknij</Button>
                    </Modal.Footer>
                </Modal>
            </div>
        </div>                
    )
}
