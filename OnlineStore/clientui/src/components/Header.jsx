import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

function Header() {
    const [user, setUser] = useState(null);
    const navigate = useNavigate();

    useEffect(() => {
        // Загружаем данные о пользователе из localStorage
        const savedUser = JSON.parse(localStorage.getItem('user'));
        setUser(savedUser);
    }, [navigate]);

    const handleSignOut = () => {
        localStorage.removeItem('user'); // Удаляем пользователя из localStorage
        setUser(null); // Обнуляем состояние пользователя
    };

    return (
        <header data-bs-theme="dark">
            <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
                <div className="container-fluid">
                    <a className="navbar-brand" href="/">Online Store</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false"
                            aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarCollapse">
                        <ul className="navbar-nav me-auto mb-2 mb-md-0">
                            <li className="nav-item">
                                <a className="nav-link active" aria-current="page" href="/">Home</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/cart">Cart</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link disabled" aria-disabled="true">Disabled</a>
                            </li>
                        </ul>
                        <div className="d-flex align-items-center">
                            {user ? (
                                <>
                                    <span className="me-3 text-white">{user.email}</span>
                                    <button className="btn btn-outline-danger" onClick={handleSignOut}>Sign Out</button>
                                </>
                            ) : (
                                <a href="/login" className="btn btn-outline-success">Sign In</a>
                            )}
                        </div>
                    </div>
                </div>
            </nav>
        </header>
    );
}

export default Header;