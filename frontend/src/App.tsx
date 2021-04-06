import React from 'react';
import { BrowserRouter, Switch, Route } from "react-router-dom";
import { Header } from "./parts/Header";
import { Footer } from './parts/Footer';
import ShelterProfile from './pages/ShelterProfile';
import { Home } from './pages/Home';
import AnimalCard from './components/AnimalCard';
import ShelterList from './pages/ShelterList';
import { connect } from 'react-redux';
import AnimalList from './pages/AnimalList';
import AnimalCardEdit from './components/AnimalCardEdit';
import ShelterForm from './components/ShelterForm';

export const App: React.FC = () => {

  return (
    <BrowserRouter>
      <div className="page-flexbox-wrapper">
        <header>
          <Header />
        </header>
        <main>
          <Switch>
            <Route component={Home} path="/" exact></Route>
            <Route component={ShelterList} path="/search" exact></Route>
            <Route component={ShelterProfile} path="/shelter/:shelterid" exact></Route>
            <Route component={ShelterForm} path="/shelter/:shelterid/edit" exact></Route>
            <Route component={AnimalList} path="/shelter/:shelterid/pets" ></Route>
            <Route component={AnimalCard} path="/shelter/:shelterid/pet/:animalid" exact></Route>
            <Route component={AnimalCardEdit} path="/shelter/:shelterid/pet/:animalid/edit" exact></Route>
          </Switch>
        </main>
        <Footer />
      </div>
    </BrowserRouter>
  );
}

export default connect(null, null)(App);