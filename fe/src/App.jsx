import { useState } from 'react'

import './App.css'
import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Link, Outlet } from 'react-router-dom';

import LoginScreen from './LoginPage';
import FileUploadd from './FileUpload';
import FileList from './FileList';

function FileUpload() {
    return <FileUploadd />
}

function Navbar() {
    return (
        <nav >
            <ul>
                <li>
                    <Link to="/LoginPage">Login</Link>
                </li>
                <li>
                    <Link to="/FileUpload">FileUpload</Link>
                </li>
                <li>
                    <Link to="/FileList">FileList</Link>
                </li>
           
            </ul>
        </nav>
    );
}
function App() {
    return (
        <>
       
        <BrowserRouter>
        <Navbar />
            <Routes>
                <Route path="/LoginPage" element={<LoginScreen />} />
                <Route path="/FileUpload" element={<FileUpload />} />
                <Route path="/FileList" element={<FileList />} />
            </Routes>
        </BrowserRouter>
        </>
    );
}

export default App;
