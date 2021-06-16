import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Navigation from './navbar/Navigation';
import Phonebook from './phonebook/Phonebook';

class App extends React.Component{
  render() {
    return(
      <Router>
        <div>
          <Navigation/>
          <Switch>
            <Route path="/phonebook" component={Phonebook}/>
          </Switch>
        </div>
      </Router>
    );
  }
}

export default App;
