import React, { useState } from 'react';

const Register = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const [confirmPasswordError, setConfirmPasswordError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

  const onSubmit = () => {
    setEmailError('');
    setPasswordError('');
    setConfirmPasswordError('');
    setSuccessMessage('');

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

    if (password !== confirmPassword) {
      setConfirmPasswordError('Passwords do not match');
      return;
    }

    // Simulate successful registration (API call would go here)
    setSuccessMessage('Your account has been created successfully.');
  };

  return (
    <div className="mainContainer">
      <div className="registerBox">
        <h2 className="registerTitle">Register</h2>

        <div className="inputContainer">
          <input
            type="text"
            value={email}
            placeholder="Enter your email"
            onChange={(ev) => setEmail(ev.target.value)}
            className="inputBox"
          />
          <label className="errorLabel">{emailError}</label>
        </div>

        <div className="inputContainer">
          <input
            type="password"
            value={password}
            placeholder="Enter your password"
            onChange={(ev) => setPassword(ev.target.value)}
            className="inputBox"
          />
          <label className="errorLabel">{passwordError}</label>
        </div>

        <div className="inputContainer">
          <input
            type="password"
            value={confirmPassword}
            placeholder="Confirm your password"
            onChange={(ev) => setConfirmPassword(ev.target.value)}
            className="inputBox"
          />
          <label className="errorLabel">{confirmPasswordError}</label>
        </div>

        <div className="inputContainer">
          <input className="inputButton" type="button" onClick={onSubmit} value="Register" />
        </div>

        {successMessage && <p className="successMessage">{successMessage}</p>}
      </div>
    </div>
  );
};

export default Register;
