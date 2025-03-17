function Header() {
    return (
        <div className="container-fluid">
            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample11" aria-controls="navbarsExample11" aria-expanded="false"
                    aria-label="Toggle navigation">
                <span className="navbar-toggler-icon"></span>
            </button>

            <div className="collapse navbar-collapse d-lg-flex" id="navbarsExample11">
                <a className="navbar-brand col-lg-3 me-0" href="#">Centered nav</a>
                <ul className="navbar-nav col-lg-6 justify-content-lg-center">
                    <li className="nav-item">
                        <a className="nav-link active" aria-current="page" href="#">Home</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="#">Link</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link disabled" aria-disabled="true">Disabled</a>
                    </li>
                    <li className="nav-item dropdown">
                        <a className="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown" aria-expanded="false">Dropdown</a>
                        <ul className="dropdown-menu">
                            <li><a className="dropdown-item" href="#">Action</a></li>
                            <li><a className="dropdown-item" href="#">Another action</a></li>
                            <li><a className="dropdown-item" href="#">Something else here</a></li>
                        </ul>
                    </li>
                </ul>
                <div className="d-lg-flex col-lg-3 justify-content-lg-end">
                    <button className="btn btn-primary">Button</button>
                </div>
            </div>
        </div>
    );
}

export default Header;