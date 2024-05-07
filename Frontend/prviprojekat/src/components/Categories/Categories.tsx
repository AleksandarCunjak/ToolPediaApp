import React, { useState } from "react";
import "./Categories.css"; // Stilovi za kategorije
import toolService from "../../services/toolService.tsx";
import ToolFilter from "../../models/Filter.tsx";
import ToolType from "../../models/ToolType.tsx";

const Categories: React.FC = () => {
  const [showSubcategories, setShowSubcategories] = useState<{
    [key: string]: boolean;
  }>({});
  // const [tools, setTools] = useState<Tool[]>([]);

  const toggleSubcategories = (category: string) => {
    setShowSubcategories((prevState) => ({
      ...prevState,
      [category]: !prevState[category],
    }));
  };

  // const showDrills = async () => {
  //   const filter: ToolFilter = {
  //     toolType: [ToolType.Busilica],
  //     powerSupply: null,
  //     brand: null,
  //     priceBetween: null,
  //     dateCreatedAfter: null,
  //   };
  //   try {
  //     debugger;
  //     const drills = await toolService.filterTools(filter, "price");

  //     if (drills !== undefined) {
  //       setTools(drills);
  //     }
  //   } catch (error) {
  //     console.error("Error fetching tools:", error);
  //   }
  // };

  return (
    <div className="categories">
      <div
        className="category"
        onClick={() => toggleSubcategories("drillsImpact")}
      >
        <button className="main-category">DRILLS & IMPACT</button>
        {showSubcategories["drillsImpact"] && (
          <div className="sub-categories">
            <button>Drills</button>
            <button>Impact</button>
          </div>
        )}
      </div>
      <div className="category">
        <button className="main-category">GRINDERS</button>
      </div>
      <div className="category">
        <button className="main-category">ROUTERS</button>
      </div>
      <div className="category">
        <button className="main-category">SANDERS</button>
      </div>
      <div className="category">
        <button className="main-category">NAILERS</button>
      </div>
      <div className="category">
        <button className="main-category">HEAT GUNS</button>
      </div>
      <div className="category">
        <button className="main-category">PLANERS</button>
      </div>
    </div>
  );
};

export default Categories;
