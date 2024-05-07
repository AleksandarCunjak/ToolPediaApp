import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./pages/Home.tsx";
import Login from "./components/LogIn/Login";
import Header from "./components/Header/Header.js";
import Footer from "./components/Footer/Footer.js";
import "./App.css";

const App = () => {
  return (
    <div>
      <Router>
        <Header />
        <div className="mx-18">
          <Routes>
            <Route exact path="/" element={<Home title="Home" />} />
            <Route
              exact
              path="/login"
              element={<Login title="Login" />}
            ></Route>
          </Routes>
        </div>
        <Footer />
      </Router>
    </div>
  );
};

export default App;
