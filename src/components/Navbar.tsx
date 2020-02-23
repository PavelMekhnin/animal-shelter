import React from 'react';

export const Navbar: React.FC = () => (
    <nav>
        <div className="nav-wrapper grey darken-3 px1">
            <a href="#" className="brand-logo">Animal shelter</a>
            <ul className="right hide-on-med-and-down">
                <li><a href="/">Home</a></li>
                <li><a href="/">Search</a></li>
                <li><a href="/">About</a></li>
            </ul>
        </div>
    </nav>
)
