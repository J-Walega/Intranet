
import axios from 'axios';
import React from 'react';
import './Phonebook.css';

export default class Phonebook extends React.Component {
    state = {
        phones: []
    }


componentDidMount() {
    axios.get('https://localhost:44332/api/v1/phones')
        .then(res => {
            const phones = res.data;
            this.setState({ phones });
        })
}

render() {
    return (
        <ul>
            {this.state.phones.map(phone => <li>{phone.number}</li>)}
        </ul>
    )
 }
}
