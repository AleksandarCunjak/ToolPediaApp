import React, { useEffect, useState } from "react";
import ToolCarousel from "../components/ToolCarousel/ToolCarousel.tsx";
import Header from "../components/Header/Header.js";
import Categories from "../components/Categories/Categories.tsx";
import BrandBox from "../components/BrandBox/BrandBox.tsx";
import Footer from "../components/Footer/Footer.js";
import LatestArticles from "../components/LatestArticles/LatestArticles.tsx";

const Home = () => {
  return (
    <div className="mb-8">
      <Categories />
      <div className="grid-cols-4 gap-4 grid mt-8 mb-8">
        <BrandBox />
        <LatestArticles />
      </div>

      <ToolCarousel />
    </div>
  );
};

export default Home;
