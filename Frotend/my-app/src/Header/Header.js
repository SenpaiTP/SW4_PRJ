import React from 'react';
import './Header.css'; // Import the CSS file

const Header = () => {
  return (
    <header className="header">
      <div className="logo-name">
        <img src="/Header/au.png" alt="Logo" className="logo" /> 
        <h1>Juhl</h1>
      </div>
      <nav className="menu">
        <a href="/Frontpage">Frontpage</a>
        <a href="/Indkomst">Indkomst</a>
        <a href="/Indstillinger">Indstillinger</a>
        <a href="/Udgifter">Udgifter</a>
      </nav>
      <div className="login-section">
        <a href="/Login" className="login-link">
          <div className="profile-icon">
            <span role="img" aria-label="profile" className="profile-emoji">👤</span>
          </div>
          <span className="login-text">Login</span>
        </a>
      </div>
    </header>
  );
};

export default Header;
