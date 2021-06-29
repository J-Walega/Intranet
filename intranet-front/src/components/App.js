import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Login from './login/Login';
import Phonebook from './phonebook/Phonebook';
import Navigation from './navbar/Navigation';

function setToken(userToken) {
  localStorage.setItem('token', JSON.stringify(userToken))
}

function getToken() {
  const tokenString = localStorage.getItem('token');
  const userToken = JSON.parse(tokenString);
  return userToken?.token
}

function App() {
  const token = getToken();

  if(!token) {
    return <Login setToken={setToken} />
  }

  return(
    <Router>
        <Navigation/>
        <Switch>
          <Route path="/phonebook" component={Phonebook}/>
          <Route path="/login" component={Login}/>
        </Switch>
    </Router>
  );
}
  
export default App;
