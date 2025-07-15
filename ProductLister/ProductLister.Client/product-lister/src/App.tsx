import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { Header } from "./components/Header";
import './App.css'

import { Main } from "./pages/Main";

function App() {
  return (
    <BrowserRouter>
      <div>
        <Header />
        <div>
          <Routes>
            <Route path="/" element={<Navigate to="/products" replace/>} />
            <Route path="/products" element={<Main/>} />
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  )
}

export default App
