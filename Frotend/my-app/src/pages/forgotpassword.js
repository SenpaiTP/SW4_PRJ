import React, { useState } from 'react';

const ForgotPassword = () => {
  const [email, setEmail] = useState('');
  const [emailError, setEmailError] = useState('');
  const [successMessage, setSuccessMessage] = useState('');

  const onSubmit = () => {
    setEmailError('');
    setSuccessMessage('');

    if ('' === email) {
      setEmailError('Please enter your email');
      return;
    }

    if (!/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(email)) {
      setEmailError('Please enter a valid email');
      return;
    }

    // Simulate sending a reset link (you would call an API here)
    setSuccessMessage('A password reset link has been sent to your email.');
  };

  return (
    <div className="mainContainer">
      <div className="forgotPasswordBox">
        <h2 className="forgotPasswordTitle">Forgot Password</h2>

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
          <input className="inputButton" type="button" onClick={onSubmit} value="Send Reset Link" />
        </div>

        {successMessage && <p className="successMessage">{successMessage}</p>}
      </div>
    </div>
  );
};

export default ForgotPassword;
