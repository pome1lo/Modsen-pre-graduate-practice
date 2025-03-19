import React from 'react';

const FilterPanel = ({ inputValue, setInputValue, selectedCategory, setSelectedCategory, minPrice, setMinPrice, maxPrice, categories }) => {
    return (
        <div className="mb-4 p-3 border rounded bg-light">
            <h2>Filter Products</h2>
            <div className="row">
                <div className="col-md-4">
                    <input
                        type="text"
                        className="form-control"
                        placeholder="Search by name"
                        value={inputValue}
                        onChange={(e) => setInputValue(e.target.value)}
                    />
                </div>
                <div className="col-md-4">
                    <select
                        className="form-select"
                        value={selectedCategory}
                        onChange={(e) => setSelectedCategory(e.target.value)}
                    >
                        <option value="">All Categories</option>
                        {categories.map(category => (
                            <option key={category.id} value={category.id}>
                                {category.name}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="col-md-4">
                    <div className="d-flex">
                        <input
                            type="number"
                            className="form-control me-2"
                            placeholder="Min Price"
                            value={minPrice}
                            onChange={(e) => setMinPrice(e.target.value)}
                        />
                        <input
                            type="number"
                            className="form-control"
                            placeholder="Max Price"
                            value={maxPrice}
                            onChange={(e) => setMaxPrice(e.target.value)}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default FilterPanel;