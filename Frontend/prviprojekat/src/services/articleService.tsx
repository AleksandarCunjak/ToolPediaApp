import Articles from "../models/Articles";

const articleService = {
  async getAllArticles(page: number = 0, perPage: number = 5) {
    try {
      const response = await fetch(
        `http://localhost:5039/api/articles/articles?page=${page}&perPage=${perPage}`
      );
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const articles: Articles = await response.json();
      return articles;
    } catch (error) {
      console.error("There was a problem with the fetch operation:", error);
    }
  },
};
export default articleService;
