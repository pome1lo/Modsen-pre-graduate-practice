import './App.css'
import BasicLayout from "./layout/BasicLayout.jsx";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from './components/HomePage'
import LoginPage from "./pages/LoginPage.jsx";
import RegisterPage from "./pages/RegisterPage.jsx";

function App() {
    return (
        <Router>
            <BasicLayout>
                <Routes>
                    <Route path="/" element={<HomePage/>} />
                    <Route path="/about" element={<h1>About Page</h1>} />
                    <Route path="/login" element={<LoginPage/>} />
                    <Route path="/register" element={<RegisterPage/>} />
                    <Route path="/catalog" element={<h1>Catalog Page</h1>} />
                    <Route path="/profile" element={<h1>Profile Page</h1>} />
                </Routes>
            </BasicLayout>
        </Router>
    )
}

export default App
