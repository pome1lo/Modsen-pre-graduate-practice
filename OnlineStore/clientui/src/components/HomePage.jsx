import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import FilterPanel from './UI/FilterPanel';
import Pagination from './UI/Pagination';
import 'bootstrap/dist/css/bootstrap.min.css';

const categoriesData = [
    { id: '1', name: 'Electronics' },
    { id: '2', name: 'Books' },
    { id: '3', name: 'Clothing' },
];

const productsData = [
    { id: 1, name: 'Product 1', price: 29.99, categoryId: '1' },
    { id: 2, name: 'Product 2', price: 39.99, categoryId: '2' },
    { id: 3, name: 'Product 3', price: 19.99, categoryId: '1' },
    { id: 4, name: 'Product 4', price: 49.99, categoryId: '3' },
    { id: 5, name: 'Product 5', price: 29.99, categoryId: '1' },
    { id: 6, name: 'Product 6', price: 39.99, categoryId: '2' },
    { id: 7, name: 'Product 7', price: 19.99, categoryId: '1' },
    { id: 8, name: 'Product 8', price: 49.99, categoryId: '3' },
    { id: 9, name: 'Product 9', price: 29.99, categoryId: '1' },
    { id: 10, name: 'Product 10', price: 39.99, categoryId: '2' },
    { id: 11, name: 'Product 11', price: 19.99, categoryId: '1' },
    { id: 12, name: 'Product 12', price: 49.99, categoryId: '3' },
    { id: 13, name: 'Product 13', price: 29.99, categoryId: '1' },
    { id: 14, name: 'Product 14', price: 39.99, categoryId: '2' },
    { id: 15, name: 'Product 15', price: 19.99, categoryId: '1' },
    { id: 16, name: 'Product 16', price: 49.99, categoryId: '3' },
];

function HomePage() {
    const navigate = useNavigate();
    const [currentPage, setCurrentPage] = useState(1);
    const [inputValue, setInputValue] = useState('');
    const [selectedCategory, setSelectedCategory] = useState('');
    const [minPrice, setMinPrice] = useState('');
    const [maxPrice, setMaxPrice] = useState('');
    const [categories] = useState(categoriesData);
    const [products] = useState(productsData);
    const itemsPerPage = 12;

    const indexOfLastProduct = currentPage * itemsPerPage;
    const indexOfFirstProduct = indexOfLastProduct - itemsPerPage;

    const filteredProducts = products.filter(product => {
        const priceCondition = (minPrice ? product.price >= minPrice : true) && (maxPrice ? product.price <= maxPrice : true);
        const categoryCondition = selectedCategory ? product.categoryId === selectedCategory : true;
        const nameCondition = product.name.toLowerCase().includes(inputValue.toLowerCase());
        return priceCondition && categoryCondition && nameCondition;
    });

    const currentProducts = filteredProducts.slice(indexOfFirstProduct, indexOfLastProduct);
    const totalPages = Math.ceil(filteredProducts.length / itemsPerPage);

    const handlePageChange = (pageNumber) => {
        if (pageNumber >= 1 && pageNumber <= totalPages) {
            setCurrentPage(pageNumber);
        }
    };

    const goToPage = () => {
        const pageNumber = Number(inputValue);
        handlePageChange(pageNumber);
    };

    const handleProductClick = (productId) => {
        navigate(`/product/${productId}`);
    };

    const addToCart = (product) => {
        const cartItems = JSON.parse(localStorage.getItem('cart')) || [];
        
        const existingProduct = cartItems.find(item => item.id === product.id);
        if (existingProduct) {
            alert('Product already in the cart');
        } else {
            cartItems.push(product);
            localStorage.setItem('cart', JSON.stringify(cartItems));
            alert('Product added to cart');
        }
    };

    return (
        <div className="container mt-5">
            <FilterPanel
                inputValue={inputValue}
                setInputValue={setInputValue}
                selectedCategory={selectedCategory}
                setSelectedCategory={setSelectedCategory}
                minPrice={minPrice}
                setMinPrice={setMinPrice}
                maxPrice={maxPrice}
                setMaxPrice={setMaxPrice}
                categories={categories}
            />
            <div className="row">
                {currentProducts.map((product, index) => (
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
                                <button className="btn btn-primary" onClick={(e) => {
                                    e.stopPropagation();
                                    addToCart(product);
                                }}>
                                    Add to Cart
                                </button>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
            <Pagination
                currentPage={currentPage}
                totalPages={totalPages}
                handlePageChange={handlePageChange}
                inputValue={inputValue}
                goToPage={goToPage}
                handleInputChange={(e) => setInputValue(e.target.value)}
            />
        </div>
    );
}

export default HomePage;