import React from 'react';
import { Navbar } from "./components/Navbar";
import { Footer } from './components/Footer';
import { ShelterProfile } from './components/ShelterProfile';
import { Home } from './components/Home';
import { AnimalCard } from './components/AnimalCard';
import { ShelterList } from './components/ShelterList';

function App() {
  return (
    <>
      <header>
        <Navbar />
      </header>
      <main className="cont">
        <div className='row'></div>
        <ShelterProfile />
      </main>
      <Footer />
    </>
  );
}

export default App;
