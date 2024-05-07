import React, { useState, useEffect } from 'react';
import './MostVisitedArticles.css';

const MostVisitedArticles = () => {
  const [articles, setArticles] = useState([]);

  useEffect(() => {
    fetchArticles();
  }, []);

  const fetchArticles = async () => {
    try {
      const response = await fetch('/api/articles?sortBy=date&order=desc');
      const data = await response.json();
      setArticles(data);
    } catch (error) {
      console.error('Error fetching articles:', error);
    }
  };

  const formatTimeAgo = (time) => {
    const now = new Date();
    const diffMs = now - time;
    const seconds = Math.floor(diffMs / 1000);
    const minutes = Math.floor(seconds / 60);
    const hours = Math.floor(minutes / 60);
    const days = Math.floor(hours / 24);
    const years = Math.floor(days / 365);

    if (years > 0) return `${years} year(s) ago`;
    if (days > 0) return `${days} day(s) ago`;
    if (hours > 0) return `${hours} hour(s) ago`;
    if (minutes > 0) return `${minutes} minute(s) ago`;
    return `${seconds} second(s) ago`;
  };

  return (
    <div className="articles-list">
      <h2>Članci</h2>
      <ul>
        {articles.map((article, index) => (
          <li key={index}>
            <img
              className="article-image"
              src={article.image}
              alt={`${article.title} thumbnail`}
            />
            <h3>{article.title}</h3>
            <p>{article.content}</p>
            <div className="article-info">
              <span className="author">{article.author}</span>
              <span className="time-ago">{formatTimeAgo(article.time)}</span>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default MostVisitedArticles;