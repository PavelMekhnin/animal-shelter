import React, { useEffect } from 'react';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import { Navbar } from "./components/Navbar";
import { Footer } from './components/Footer';
import ShelterProfile from './components/ShelterProfile';
import { Home } from './components/Home';
import AnimalCard from './components/AnimalCard';
import ShelterList from './components/ShelterList';
import { connect } from 'react-redux';
import { AnimalList } from './components/AnimalList';

export const App : React.FC  = () =>{

    return (
      <BrowserRouter>
        <header>
          <Navbar />
        </header>
        <main className="cont">
          <div className='row'></div>
          <Switch>
            <Route component={Home} path="/" exact></Route>
            <Route component={ShelterList} path="/search" exact></Route>
            <Route component={ShelterProfile} path="/shelter/:shelterid" exact></Route>
            <Route component={AnimalList} path="/shelter/:shelterid/pets" ></Route>
            <Route component={AnimalCard} path="/shelter/:shelterid/pet/:animalid" exact></Route>
          </Switch>
        </main>
        <Footer />
      </BrowserRouter>
    );
}

export default connect(null, null)(App);