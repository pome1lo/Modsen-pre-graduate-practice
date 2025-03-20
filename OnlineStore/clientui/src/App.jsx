import './App.css'
import BasicLayout from "./layout/BasicLayout.jsx";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './pages/HomePage'
import LoginPage from "./pages/LoginPage.jsx";
import RegisterPage from "./pages/RegisterPage.jsx";
import CartPage from './pages/CartPage';
import ProductPage from './pages/ProductPage';

function App() {
    return (
        <Router>
            <BasicLayout>
                <Routes>
                    <Route path="/" element={<HomePage/>} />
                    <Route path="/login" element={<LoginPage/>} />
                    <Route path="/register" element={<RegisterPage/>} />
                    <Route path="/cart" element={<h1><CartPage/></h1>} />
                    <Route path="/product/:productId" element={<h1><ProductPage/></h1>} />
                </Routes>
            </BasicLayout>
        </Router>
    )
}

export default App
