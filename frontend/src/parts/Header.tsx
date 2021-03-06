import React from 'react';
import { Link } from 'react-router-dom';

export const Header = () => (
    <nav>
        <div className="nav-wrapper grey darken-4 px1">
            <a href="/" className="brand-logo">Animal shelter</a>
            <ul className="right hide-on-med-and-down">
                <li><Link to="/search">Search</Link></li>
                <li><a href="/">Login (developing)</a></li>
            </ul>
        </div>
    </nav>
)
