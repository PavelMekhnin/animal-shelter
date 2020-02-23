import React from 'react';
import { Navbar} from "./components/Navbar";
import { Footer } from './components/Footer';
import { ShelterProfile } from './components/ShelterProfile';

function App() {
  return (
    <>
    <Navbar />

      <div>
        <ShelterProfile />
      </div>

      <Footer/>
    </>
  );
}

export default App;
