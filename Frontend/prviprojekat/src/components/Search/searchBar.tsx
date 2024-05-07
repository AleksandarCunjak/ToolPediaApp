import React, { useState, useEffect } from "react";
import { debounce } from "lodash";
import "./searchBar.css";
import toolService from "../../services/toolService.tsx";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [suggestions, setSuggestions] = useState<Tool[]>([]);
  const [isFocused, setIsFocused] = useState(false);

  const fetchSuggestions = async (searchTerm: string) => {
    const toolList = await toolService.searchTools(searchTerm);
    if (toolList !== undefined) {
      setSuggestions(toolList.slice(0, 5));
    }
  };

  const debouncedFetchSuggestions = debounce(fetchSuggestions, 300);

  useEffect(() => {
    if (searchTerm.length > 2) {
      debouncedFetchSuggestions(searchTerm);
    } else {
      setSuggestions([]);
    }
  }, [searchTerm]);

  const handleSearchInputChange = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setSearchTerm(event.target.value);
  };

  const handleSuggestionClick = (suggestion: Tool) => {
    //onSearch(suggestion);
    debugger;
    alert("suggestion clicked");
  };

  const handleFocus = () => {
    debugger;
    setIsFocused(true); // Set focus state to true when input is focused
  };

  const handleBlur = () => {
    debugger;
    setIsFocused(false); // Set focus state to false when input loses focus
  };

  return (
    <div className="search-container">
      <input
        type="text"
        className="search-input"
        value={searchTerm}
        onChange={handleSearchInputChange}
        onBlur={handleBlur}
        onFocus={handleFocus}
        placeholder="Search..."
      />
      {isFocused && (
        <ul className="suggestions-list">
          {suggestions.map((suggestion, index) => (
            <li
              key={index}
              className="suggestions-item"
              onMouseDown={() => handleSuggestionClick(suggestion)}
            >
              {suggestion.name}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default Search;
