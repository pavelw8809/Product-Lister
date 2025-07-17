import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { Header } from "./components/Header/Header";
import './App.css'

import { Main } from "./pages/Main";
import { Category } from './pages/Category';

function App() {
  return (
    <BrowserRouter>
      <div>
        <Header />
        <div>
          <Routes>
            <Route path="/" element={<Navigate to="/products" replace/>} />
            <Route path="/products" element={<Main/>} />
			<Route path="/categories" element={<Category/> }/>
          </Routes>
        </div>
      </div>
    </BrowserRouter>
  )
}

export default App
