import React, { useState } from "react";
import "./Header.css"; // stilovi za header
import LoginTab from "../LogIn/LoginTab";
import LoginIcon from "../LogIn/LogInIcon";
import SearchBar from "../Search/searchBar.tsx";

const Header = () => {
  return (
    <header className="header-container">
      <div className="logo">
        <img src="putanja/do/loga.png" alt="Logo" width="100" height="150" />
      </div>
      <div className="search-bar-container">
        <SearchBar></SearchBar>
      </div>
      <div className="account-container">
        <LoginTab>
          <LoginIcon />
        </LoginTab>
      </div>
    </header>
  );
};

export default Header;
