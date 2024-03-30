import { useState } from 'react'
import reactLogo from './assets/react.svg'
import mojLogo from '/vite.svg'
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import NavBar from './components/NavBar'
import { Route, Routes } from 'react-router-dom'
import { RoutesNames } from './constants'
import Pocetna from './pages/Pocetna'
import Mjesta from './pages/mjesta/Mjesta'
import MjestaDodaj from './pages/mjesta/MjestaDodaj'


function App() {


  return (
    <>
      <NavBar />
      <Routes>
        <Route path={RoutesNames.HOME} element={<Pocetna />} />

        <Route path={RoutesNames.MJESTO_PREGLED} element={<Mjesta />} />
        
        
      </Routes>
    </>
  )
}

export default App
