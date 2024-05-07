import React from "react";
import { useNavigate } from "react-router-dom";

const LoginTab = ({ isLoggedIn, children }) => {
  const navigate = useNavigate();

  const handleLogin = (email, password) => {
    // Handle login logic
    // After successful login, redirect to the account page
    navigate("/profile"); // Change this to the path of your user profile page
  };

  const handleLoginIconClick = () => {
    if (isLoggedIn) {
      navigate("/profile"); // Change this to the path of your user profile page
    } else {
      // Open the login or signup page in a new tab
      navigate("/login"); // Change this to the path of your login or signup page
    }
  };

  return (
    <div className="login-tab" onClick={handleLoginIconClick}>
      {children}
    </div>
  );
};

export default LoginTab;
