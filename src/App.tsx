import React from 'react';
import { Navbar } from "./components/Navbar";
import { Footer } from './components/Footer';
import { ShelterProfile } from './components/ShelterProfile';
import { Home } from './components/Home';

function App() {
  return (
    <>
      <header>
        <Navbar />
      </header>
      <main>
        <Home />
      </main>
      <Footer />
    </>
  );
}

export default App;
