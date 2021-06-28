import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Login from './login/Login';
import Phonebook from './phonebook/Phonebook';
import Navigation from './navbar/Navigation';

class App extends React.Component{
  render() {
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
}

export default App;
