import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Routes, Navigate } from 'react-router-dom';

import './index.css';

import Home from './pages/home/App';
import Login from './pages/login/Login';
import Consultas from './pages/Consultas/Consultas';
import NotFound from './pages/NotFound/NotFound';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Routes>
        <Route exact path="/" element={<Home/>}/>
        <Route path="/login" element={<Login/>}/>
        <Route path="/Consultas" element={<Consultas/>}/>
        <Route path="/notfound" element={<NotFound/>}/>
        <Route path="*" element={<Navigate to ="/notfound" />}/>
      </Routes>
    </div>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
