import React, { useEffect, useState } from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Link } from "react-router-dom";
import Tools from "../../models/Tools";
import toolService from "../../services/toolService.tsx";

const ToolCarousel: React.FC = () => {
  const [tools, setTools] = useState<Tools | null>(null);

  useEffect(() => {
    fetchTools();
  }, []);

  const fetchTools = async (page: number = 0, perPage: number = 20) => {
    try {
      const toolsData = await toolService.getAllTools(page, perPage);
      if (toolsData !== undefined) {
        setTools(toolsData);
      }
    } catch (error) {
      console.error("Error fetching tools:", error);
    }
  };

  return (
    <div className="slider-container">
      {tools &&
        tools.tools &&
        tools.tools.map((tool, index) => (
          <div key={tool.id} className="tool-item">
            <div className="tool-image">
              <img
                src="https://cdn.directtoolsoutlet.com/resize/100/A972502_01.jpg"
                alt={tool.name}
              />
            </div>
            <div className="tool-info">
              <h3 className="tool-name">{tool.name}</h3>
              <p className="tool-description">
                {tool.description || "No description available"}
              </p>
              <p className="tool-price">Price: ${tool.price}</p>
            </div>
            <Link to={`/tool/${tool.name}`} className="tool-link">
              View Details
            </Link>
          </div>
        ))}
    </div>
  );
};

export default ToolCarousel;
