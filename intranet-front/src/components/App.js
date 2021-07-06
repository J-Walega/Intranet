import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Login from './login/Login';
import Phonebook from './phonebook/Phonebook';
import Navigation from './navbar/Navigation';

function setToken(userToken) {
  sessionStorage.setItem('token', JSON.stringify(userToken))
}

function App() {

  return(
    <Router>
        <Navigation/>
        <Switch>
          <Route path="/phonebook" component={Phonebook}/>
          <Route path="/login" render={props => <Login setToken = {setToken}/>}/>
        </Switch>
    </Router>
  );
}
  
export default App;
