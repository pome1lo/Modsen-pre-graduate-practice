import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

function ProductPage() {
    const { productId } = useParams(); // Получаем id продукта из URL
    const [product, setProduct] = useState(null); // Состояние для хранения информации о продукте
    const navigate = useNavigate();

    useEffect(() => {
        // Имитируем получение продукта по ID (в реальном приложении можно получать данные из API)
        const productsData = [
            { id: 1, name: 'Product 1', price: 29.99, description: 'Description for Product 1', categoryId: '1' },
            { id: 2, name: 'Product 2', price: 39.99, description: 'Description for Product 2', categoryId: '2' },
            { id: 3, name: 'Product 3', price: 19.99, description: 'Description for Product 3', categoryId: '1' },
            { id: 4, name: 'Product 4', price: 49.99, description: 'Description for Product 4', categoryId: '3' },
            { id: 5, name: 'Product 5', price: 29.99, description: 'Description for Product 5', categoryId: '1' },
            { id: 6, name: 'Product 6', price: 39.99, description: 'Description for Product 6', categoryId: '2' },
            { id: 7, name: 'Product 7', price: 19.99, description: 'Description for Product 7', categoryId: '1' },
            { id: 8, name: 'Product 8', price: 49.99, description: 'Description for Product 8', categoryId: '3' },
            { id: 9, name: 'Product 9', price: 29.99, description: 'Description for Product 9', categoryId: '1' },
            { id: 10, name: 'Product 10', price: 39.99, description: 'Description for Product 10', categoryId: '2' },
            { id: 11, name: 'Product 11', price: 19.99, description: 'Description for Product 11', categoryId: '1' },
            { id: 12, name: 'Product 12', price: 49.99, description: 'Description for Product 12', categoryId: '3' },
            { id: 13, name: 'Product 13', price: 29.99, description: 'Description for Product 13', categoryId: '1' },
            { id: 14, name: 'Product 14', price: 39.99, description: 'Description for Product 14', categoryId: '2' },
            { id: 15, name: 'Product 15', price: 19.99, description: 'Description for Product 15', categoryId: '1' },
            { id: 16, name: 'Product 16', price: 49.99, description: 'Description for Product 16', categoryId: '3' },
        ];
        
        const foundProduct = productsData.find(item => item.id === parseInt(productId));
        setProduct(foundProduct);
    }, [productId]);

    const addToCart = () => {
        if (!product) return;

        const cartItems = JSON.parse(localStorage.getItem('cart')) || [];
        const existingProduct = cartItems.find(item => item.id === product.id);
        
        if (existingProduct) {
            alert('Product already in the cart');
        } else {
            cartItems.push(product);
            localStorage.setItem('cart', JSON.stringify(cartItems));
            alert('Product added to cart!');
        }
    };

    if (!product) {
        return <div>Loading...</div>; // Показать загрузку, если продукт еще не загружен
    }

    return (
        <div className="container mt-5">
            <h2>{product.name}</h2>
            <p>Price: ${product.price.toFixed(2)}</p>
            <p>{product.description}</p>
            <button className="btn btn-primary" onClick={addToCart}>Add to Cart</button>
            <button className="btn btn-secondary ml-2" onClick={() => navigate("/")} >
                Back to Products
            </button>
        </div>
    );
}

export default ProductPage;