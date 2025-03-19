import React from 'react';

const Pagination = ({ currentPage, totalPages, handlePageChange, inputValue, goToPage, handleInputChange }) => {
    return (
        <nav>
            <ul className="pagination justify-content-center">
                <li className="page-item">
                    <button className="page-link" onClick={() => handlePageChange(1)}>First</button>
                </li>
                <li className="page-item">
                    <button className="page-link" onClick={() => handlePageChange(currentPage - 1)} disabled={currentPage === 1}>
                        Previous
                    </button>
                </li>
                <li className="page-item">
                    <span className="page-link">{currentPage} / {totalPages}</span>
                </li>
                <li className="page-item">
                    <button className="page-link" onClick={() => handlePageChange(currentPage + 1)} disabled={currentPage === totalPages}>
                        Next
                    </button>
                </li>
                <li className="page-item">
                    <button className="page-link" onClick={() => handlePageChange(totalPages)}>Last</button>
                </li>
                <li className="page-item">
                    <input
                        type="number"
                        className="form-control"
                        min="1"
                        max={totalPages}
                        value={inputValue}
                        onChange={handleInputChange}
                        placeholder="Page"
                        style={{ width: '80px', marginLeft: '10px' }}
                    />
                </li>
                <li className="page-item">
                    <button className="btn btn-primary" onClick={goToPage}>
                        Go
                    </button>
                </li>
            </ul>
        </nav>
    );
};

export default Pagination;