import React from "react";
import "./BrandBox.css"; // Stilovi za BrandsBox

const BrandLogoDeWalt = require("../../Images/Dewalt-Small-Logo-Button.webp");
const BrandLogoBosch = require("../../Images/Bosch-Logo-Button.webp");
const BrandLogoMilwaukee = require("../../Images/Milwaukee-Small-Logo-Button.webp");
const BrandLogoMetabo = require("../../Images/metabo-logo-vector.png");
const BrandLogoMakita = require("../../Images/makita_logo.jpg");
const BrandLogoRidgid = require("../../Images/Ridgid_logo.jpeg");
const BrandLogoSKIL = require("../../Images/SKIL_Logo.png");
const BrandLogoAeg = require("../../Images/Aeg_logo.png");
const BrandLogoHikoki = require("../../Images/hikoki-logo.png");
const BrandLogoBlackandDecker = require("../../Images/Black_Decker_logo.png");
const BrandLogoEinhell = require("../../Images/einhell_logo.png");
const BrandLogoHilti = require("../../Images/Hilti_logo.png");
const BrandLogoFestool = require("../../Images/festool.png");
const BrandLogoPorterCable = require("../../Images/porter_cable.png");
const BrandLogoKobalt = require("../../Images/kobalt.jpg");

const BrandBox = () => {
  // Definisanje brendova i njihovih slika
  const brands = [
    { name: "DeWalt", image: BrandLogoDeWalt, link: "/products?brand=DeWalt" },
    { name: "Bosch", image: BrandLogoBosch, link: "/products?brand=Bosch" },
    {
      name: "Milwaukee",
      image: BrandLogoMilwaukee,
      link: "/products?brand=Milwaukee",
    },
    { name: "Metabo", image: BrandLogoMetabo, link: "/products?brand=Metabo" },
    { name: "Makita", image: BrandLogoMakita, link: "/products?brand=Bosch" },
    {
      name: "Ridgid",
      image: BrandLogoRidgid,
      link: "/products?brand=Milwaukee",
    },
    { name: "SKIL", image: BrandLogoSKIL, link: "/products?brand=DeWalt" },
    { name: "AEG", image: BrandLogoAeg, link: "/products?brand=Bosch" },
    {
      name: "Hikoki",
      image: BrandLogoHikoki,
      link: "/products?brand=Milwaukee",
    },
    {
      name: "Einhell",
      image: BrandLogoEinhell,
      link: "/products?brand=DeWalt",
    },
    { name: "Festool", image: BrandLogoFestool, link: "/products?brand=Bosch" },
    { name: "Hilti", image: BrandLogoHilti, link: "/products?brand=Milwaukee" },
    {
      name: "Black&Decker",
      image: BrandLogoBlackandDecker,
      link: "/products?brand=DeWalt",
    },
    { name: "AEG", image: BrandLogoPorterCable, link: "/products?brand=Bosch" },
    {
      name: "Kobalt",
      image: BrandLogoKobalt,
      link: "/products?brand=Milwaukee",
    },
    // Dodajte ostale brendove ovde...
  ];

  return (
    <div className="brands-box">
      <h2 className="toolbrands mb-8">Tool Brands</h2>
      <table className="brands-table">
        <tbody>
          <tr>
            {brands.slice(0, 3).map((brand, index) => (
              <td key={index}>
                <a href={brand.link} className="brand-link">
                  <img
                    src={brand.image}
                    alt={brand.name}
                    className="brand-image"
                  />
                </a>
              </td>
            ))}
          </tr>
          <tr>
            {brands.slice(3, 6).map((brand, index) => (
              <td key={index}>
                <a href={brand.link} className="brand-link">
                  <img
                    src={brand.image}
                    alt={brand.name}
                    className="brand-image"
                  />
                </a>
              </td>
            ))}
          </tr>
          <tr>
            {brands.slice(6, 9).map((brand, index) => (
              <td key={index}>
                <a href={brand.link} className="brand-link">
                  <img
                    src={brand.image}
                    alt={brand.name}
                    className="brand-image"
                  />
                </a>
              </td>
            ))}
          </tr>
          <tr>
            {brands.slice(9, 12).map((brand, index) => (
              <td key={index}>
                <a href={brand.link} className="brand-link">
                  <img
                    src={brand.image}
                    alt={brand.name}
                    className="brand-image"
                  />
                </a>
              </td>
            ))}
          </tr>
          <tr>
            {brands.slice(12, 15).map((brand, index) => (
              <td key={index}>
                <a href={brand.link} className="brand-link">
                  <img
                    src={brand.image}
                    alt={brand.name}
                    className="brand-image"
                  />
                </a>
              </td>
            ))}
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default BrandBox;
