import ToolFilter from "../models/Filter";
import Tools from "../models/Tools";

const toolService = {
  async getAllTools(page: number = 0, perPage: number = 5) {
    try {
      const response = await fetch(
        `http://localhost:5039/api/tools/tools?page=${page}&perPage=${perPage}`
      );
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const tools: Tools = await response.json();
      return tools;
    } catch (error) {
      console.error("There was a problem with the fetch operation:", error);
    }
  },
  async searchTools(query: string) {
    try {
      const response = await fetch(
        `http://localhost:5039/api/tools/search?query=${query}`
      );
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const tools: Tools = await response.json();
      return tools;
    } catch (error) {
      console.error("There was a problem with the fetch operation:", error);
    }
  },
  async filterTools(filter: ToolFilter, sort: string) {
    try {
      const response = await fetch(
        `http://localhost:5039/api/tools/filter?sort=${sort}`,
        {
          method: "POST",
          body: JSON.stringify(filter),
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      const tools: Tools = await response.json();
      return tools;
    } catch (error) {
      console.error("There was a problem with the fetch operation:", error);
    }
  },
};

export default toolService;
