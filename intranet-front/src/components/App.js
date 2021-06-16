import React from 'react';
import { BrowserRouter as Router, Switch } from 'react-router-dom';
import './App.css';
import Navigation from './navbar/Navigation';

class App extends React.Component{
  render() {
    return(
      <Router>
        <div>
          <Navigation/>
          <Switch>
          </Switch>
        </div>
      </Router>
    );
  }
}

export default App;
