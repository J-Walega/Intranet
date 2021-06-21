import React, {Phonebook} from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Navigation from './navbar/Navigation';

class App extends React.Component{
  render() {
    return(
      <Router>
          <Navigation/>
          <Switch>
            <Route path="/phonebook" component={Phonebook}/>
          </Switch>
      </Router>
    );
  }
}

export default App;
