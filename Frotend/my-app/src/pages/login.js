import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const [rememberMe, setRememberMe] = useState(false);

  const handleRememberMeChange = (event) => {
    setRememberMe(event.target.checked);
  };

  const navigate = useNavigate();

  const onButtonClick = () => {
    setEmailError('');
    setPasswordError('');

    if ('' === email) {
      setEmailError('Please enter your email');
      return;
    }

    if (!/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(email)) {
      setEmailError('Please enter a valid email');
      return;
    }

    if ('' === password) {
      setPasswordError('Please enter a password');
      return;
    }

    if (password.length < 7) {
      setPasswordError('The password must be 8 characters or longer');
      return;
    }

    // Authentication call...
  };

  return (
    <div className="mainContainer">
      <div className="loginBox">
        <h2 className="loginTitle">Login</h2>
        
        {/* Username Input */}
        <div className="inputContainer">
          <div className="inputWithIcon">
            <span className="icon">👤</span>
            <input
              type="text"
              value={email}
              placeholder="Username@gmail.com"
              onChange={(ev) => setEmail(ev.target.value)}
              className="inputBox"
            />
          </div>
          <label className="errorLabel">{emailError}</label>
        </div>

        {/* Password Input */}
        <div className="inputContainer">
          <div className="inputWithIcon">
            <span className="icon">🔒</span>
            <input
              type="password"
              value={password}
              placeholder="Password"
              onChange={(ev) => setPassword(ev.target.value)}
              className="inputBox"
            />
          </div>
          <label className="errorLabel">{passwordError}</label>
        </div>

        {/* Remember Me & Forgot Password */}
        <div className="rememberMeContainer">
          <div>
            <input
              type="checkbox"
              id="RememberMe"
              name="RememberMe"
              checked={rememberMe}
              onChange={handleRememberMeChange}
            />
            <label htmlFor="RememberMe" className="rememberMe">Remember me</label>
          </div>
          {/* Use Link for internal navigation */}
          <Link to="/forgot-password" className="forgotPassword">Forgot Password?</Link>
        </div>

        {/* Login Button */}
        <div className="inputContainer">
          <input className="inputButton" type="button" onClick={onButtonClick} value="Login" />
        </div>

        {/* Register Link */}
        <div className="registerContainer">
          <p>Don’t have an account? <Link to="/register" className="registerLink">Register here</Link></p>
        </div>
      </div>
    </div>
  );
};

export default Login;
