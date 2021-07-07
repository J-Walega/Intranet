import React, { useEffect, useState } from 'react';
import { Table, Button, Modal, Form } from 'react-bootstrap';

//TODO: Styling, rendering logic(if user is not logged-don't render buttons)

export default function Phonebook() { 
    
    const [phones, setPhones] = useState([]);
    const [show, setShow] = useState(false);
    const [showEdit, setShowEdit] = useState(false);

    const [phoneNumber, setPhoneNumber] = useState();
    const [phoneName, setPhoneName] = useState();

    const [phoneId, setPhoneId] = useState();

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleCloseEdit = () => setShowEdit(false);
    const handleShowEdit = () => setShowEdit(true);

    const token = sessionStorage.getItem('token');

    async function addPhone(details) {
        const response = await fetch ('https://localhost:44332/api/v1/phones',{
            method: 'POST',
            headers: {
                Authorization: token,
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify({
                name: details.phoneName,
                number: details.phoneNumber
            })
        })
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
        await fetch('https://localhost:44332/api/v1/phones',
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
        await fetch('https://localhost:44332/api/v1/phones/' + id,
        {
            method: 'DELETE',
            headers:{
                Authorization: token
            }
        });
        await refreshPhones();
    }

    async function updatePhone(id, content) {
        await fetch('https://localhost:44332/api/v1/phones/' + id,
        {
            method: 'PATCH',
            headers: {
                Authorization: token,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: content.phoneName,
                number: content.phoneNumber
            })
        })
        console.log(content)
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

    const handleEdit = async e => {
        e.preventDefault();
        await updatePhone(phoneId, {
            phoneName,
            phoneNumber
        });
        handleCloseEdit();
        await refreshPhones();
    }

    function openEdit(id) {
        setPhoneId(id);
        handleShowEdit();
    }

    return (
            <div className="container px-4 mx-auto sm">
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
                            <td><Button size="sm" variant="danger" onClick={() => deletePhone(c.id)}>Usuń</Button></td>
                            <td><Button size="sm" variant="success" onClick={() => openEdit(c.id)}>Edytuj</Button></td>                        
                        </tr>
                    </tbody>
                    ))}
                </Table>

                <Button className="button" variant="primary" onClick={handleShow}>Dodaj</Button>

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

                <div>
                    <Modal show={showEdit} onHide={handleCloseEdit} animation={false}>
                        <Modal.Header closeButton>
                            <Modal.Title>Edytuj</Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <Form onSubmit={handleEdit}>
                                <Form.Group controlId = "formBasicName">
                                    <Form.Label>Nazwa</Form.Label>
                                    <Form.Control type="text" placeholder="Nazwa numeru" onChange={e => setPhoneName(e.target.value)}/>
                                </Form.Group>
                                <Form.Group>
                                    <Form.Label>Numer</Form.Label>
                                    <Form.Control type="number" placeholder="Numer telefonu" onChange={e => setPhoneNumber(e.target.value)}/>
                                </Form.Group>
                            </Form>
                        </Modal.Body>
                        <Modal.Footer>
                            <Button variant="primary" onClick={handleEdit}>Zapisz</Button>
                            <Button variant="secondary" onClick={handleCloseEdit}>Zamknij</Button>
                        </Modal.Footer>
                    </Modal>
                </div>

            </div>              
    )
}
