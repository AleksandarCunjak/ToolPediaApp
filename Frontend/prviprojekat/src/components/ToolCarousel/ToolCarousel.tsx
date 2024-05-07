import React, { useEffect, useState } from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Link } from "react-router-dom";
import Tools from "../../models/Tools";
import toolService from "../../services/toolService.tsx";
import "./ToolItem.css";

const ToolCarousel: React.FC = () => {
  const [tools, setTools] = useState<Tools | null>(null);
  const [swipeTotal, setSwipeTotal] = useState<number>(4);
  const [swipeTotalCalled, setSwipeTotalCalled] = useState<number>(1);

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

  const onSwipeFetch = (direction: string) => {
    debugger;
    if (direction.match("right")) {
      setSwipeTotal(swipeTotal + 1);

      if (swipeTotal > tools?.total!) {
        setSwipeTotalCalled(swipeTotalCalled + 1);
        fetchTools(0, 5 * swipeTotalCalled);
      }
    }
  };

  const settings = {
    dots: true,
    infinite: false,
    speed: 500,
    arrows: false,
    slidesToShow: 4,
    slidesToScroll: 1,
    responsive: [
      {
        breakpoint: 1230,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 1,
        },
      },
      {
        breakpoint: 920,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 1,
        },
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
    ],
  };

  return (
    <div className="slider-container">
      <Slider {...settings}>
        {tools &&
          tools.tools &&
          tools.tools.map((tool, index) => (
            <div key={tool.id} className="tool-item">
              <div className="tool-image">
                <img
                  src="https://www.masineialati.ba/wp-content/uploads/2020/06/makita-2012NB.jpg.webp"
                  alt={tool.name}
                />
              </div>
              <div className="tool-info">
                <h3 className="tool-name">{tool.name}</h3>
                <p className="tool-description">
                  {tool.description || "No description available"}
                </p>
                <p className="tool-price">Price: ${tool.price}</p>
                <Link to={`/tool/${tool.name}`} className="tool-link">
                  View Details
                </Link>
              </div>
            </div>
          ))}
      </Slider>
    </div>
  );
};

export default ToolCarousel;
