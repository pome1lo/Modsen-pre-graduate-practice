import React, { useState } from 'react';

function LoginPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleLogin = (e) => {
        e.preventDefault();
        // Логика для обработки входа, например, API запрос
        if (!email || !password) {
            setError('Пожалуйста, заполните все поля.');
        } else {
            // Пример запроса для входа (замените на свою логику)
            console.log('Логин:', email, password);
        }
    };

    return (
        <div className="container">
            <div className="row justify-content-center">
                <div className="col-md-6">
                    <div className="card mt-5">
                        <div className="card-body">
                            <h3 className="card-title text-center">Вход</h3>
                            {error && <div className="alert alert-danger">{error}</div>}
                            <form onSubmit={handleLogin}>
                                <div className="mb-3">
                                    <label htmlFor="email" className="form-label">Email</label>
                                    <input
                                        type="email"
                                        className="form-control"
                                        id="email"
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        required
                                    />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="password" className="form-label">Пароль</label>
                                    <input
                                        type="password"
                                        className="form-control"
                                        id="password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        required
                                    />
                                </div>
                                <button type="submit" className="btn btn-primary w-100">
                                    Войти
                                </button>
                            </form>
                            <div className="mt-3 text-center">
                                <a href="/forgot-password">Забыли пароль?</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default LoginPage;
