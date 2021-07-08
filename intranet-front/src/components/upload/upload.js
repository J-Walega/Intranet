import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';

export default function Upload() {
    
    const [description, setDescription] = useState();
    const [category, setCategory] = useState("BHP");
    const [file, setFile] = useState(null);

    const token = sessionStorage.getItem('token');


    async function uploadFile() {

        const formData = new FormData();
        formData.append("Description", description);
        formData.append("Category", category);
        formData.append("File", file);

        const response = await fetch('https://localhost:44332/api/v1/files/upload', 
        {
            method: 'POST',
            headers: {
                Authorization: token
            },
            body: formData
        });
        return response;
    }

    return (
        <div className="container">
            <Form>
                <Form.Group controlId="descriptionForm">
                    <Form.Label>Opis</Form.Label>
                    <Form.Control type="text" placeholder="Opis linku" onChange = {(e) => setDescription(e.target.value)}/>
                </Form.Group>
                <Form.Group controlId="categoryForm">
                    <Form.Label>Kategoria</Form.Label>
                    <Form.Control as="select" size="sm" onChange = {(e) => setCategory(e.target.value)}>
                        <option>BHP</option>
                        <option>Instrukcje</option>
                        <option>Zarzadzenia</option>
                    </Form.Control>
                </Form.Group>
                <Form.Group>
                    <Form.File id="fileId" type="file" onChange = {(e) => setFile(e.target.files[0])}/>
                </Form.Group>
                <Button variant="primary" onClick={() => uploadFile()}>
                    Wyślij
                </Button>
            </Form>
        </div>
    )
}