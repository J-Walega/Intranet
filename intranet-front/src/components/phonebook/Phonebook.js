import React, { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';
import './Phonebook.css';

export default function Phonebook() { 
    
    const [phones, setPhones] = useState([]);

    useEffect(() => {
        fetch('https://localhost:44332/api/v1/phones',
        {
            method: 'GET'
        })
        .then(res => res.json())
        .then(response => {
            setPhones(response);
        })
        .catch(error => console.log(error));
    })

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Nazwa</th>
                    <th>Numer</th>
                </tr>
            </thead>

            {phones.map((c, index) => (
            <tbody>
                <tr key={index}>
                    <td>{c.name}</td>
                    <td>{c.number}</td>
                </tr>
            </tbody>
            ))}
        </Table>        
    )
}
