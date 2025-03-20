import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

function CartPage() {
    const navigate = useNavigate();
    const [cartItems, setCartItems] = useState([]);
    const [user, setUser] = useState(null);

    useEffect(() => {
        const savedCart = JSON.parse(localStorage.getItem('cart')) || [];
        setCartItems(savedCart);
        const savedUser = JSON.parse(localStorage.getItem('user'));
        setUser(savedUser);
    }, []);

    const removeFromCart = (productId) => {
        const updatedCart = cartItems.filter(item => item.id !== productId);
        setCartItems(updatedCart);
        localStorage.setItem('cart', JSON.stringify(updatedCart));
    };

    const clearCart = () => {
        setCartItems([]);
        localStorage.removeItem('cart');
    };

    const handleProductClick = (productId) => {
        navigate(`/product/${productId}`);
    };

    const handleCheckout = () => {
        // Здесь можно добавить логику оформления заказа
        alert('Оформление заказа');
    };

    return (
        <div className="container mt-5">
            <h2 className="mb-4">Корзина</h2>
            {cartItems.length === 0 ? (
                <div className="alert alert-info" role="alert">
                    Ваша корзина пуста!
                </div>
            ) : (
                <div>
                    <div className="row">
                        {cartItems.map((product, index) => (
                            <div key={product.id} className="col-md-3 mb-4">
                                <div className="card" onClick={() => handleProductClick(product.id)} style={{ cursor: 'pointer' }}>
                                    <div
                                        style={{
                                            height: '150px',
                                            backgroundColor: index % 2 === 0 ? '#cf8' : '#cff',
                                            display: 'flex',
                                            justifyContent: 'center',
                                            alignItems: 'center',
                                            color: '#000',
                                            fontWeight: 'bold',
                                        }}
                                    >
                                        {product.name}
                                    </div>
                                    <div className="card-body">
                                        <h5 className="card-title">{product.name}</h5>
                                        <p className="card-text">${product.price.toFixed(2)}</p>
                                        <button className="btn btn-danger" onClick={(e) => {
                                            e.stopPropagation();
                                            removeFromCart(product.id);
                                        }}>
                                            Удалить
                                        </button>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                    <div className="d-flex justify-content-between mt-3">
                        <button className="btn btn-warning" onClick={clearCart}>
                            Очистить корзину
                        </button>
                        {user && (
                            <button className="btn btn-success" onClick={handleCheckout}>
                                Купить
                            </button>
                        )}
                    </div>
                </div>
            )}
        </div>
    );
}

export default CartPage;