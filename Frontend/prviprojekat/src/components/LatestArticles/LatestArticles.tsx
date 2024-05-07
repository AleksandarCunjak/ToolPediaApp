import React, { useEffect, useState } from "react";
import Articles from "../../models/Articles";
import articleService from "../../services/articleService.tsx";
import { url } from "inspector";
import "./LatestArticles.css";
const articleImg = require("../../Images/Articles/shaomi.jpg");

const LatestArticles = () => {
  const [articles, setArticles] = useState<Articles | null>(null);

  useEffect(() => {
    fetchArticles();
  }, []);

  const fetchArticles = async (page: number = 0, perPage: number = 4) => {
    try {
      const articlesData = await articleService.getAllArticles(page, perPage);
      if (articlesData !== undefined) {
        setArticles(articlesData);
      }
    } catch (error) {
      console.error("Error fetching articles:", error);
    }
  };

  return (
    <div
      className="grid grid-cols-2 gap-4 col-span-3 px-5"
      style={{ gridTemplateRows: "min-content" }}
    >
      <h2 className="text-xl font-bold mb-4 text-center col-span-2">Članci</h2>

      {articles &&
        articles.articles &&
        articles.articles.map((article, index) => (
          <div key={index} className="articleShowcase bg-gray-200 rounded-lg">
            <img
              src={articleImg}
              alt="asdfsdfa"
              className="articleShowcaseImage"
            />
            <div className="text-2xl font-semibold mb-2 text-center text-white title">
              {article.title}
            </div>
          </div>
        ))}
    </div>
  );
};

export default LatestArticles;
