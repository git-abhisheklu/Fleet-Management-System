import React, { useState } from "react";
// import "./CustomerCare.css";

const CustomerCare = () => {
  const [query, setQuery] = useState("");
  const [response, setResponse] = useState("");

  const handleQuerySubmit = () => {
    if (query.trim() === "") {
      setResponse("Please enter a valid query.");
      return;
    }
    
    // Simulating a response (In actual project, this should be an API call)
    setResponse("Thank you for reaching out! Our support team will contact you soon.");
    setQuery("");
  };

  return (
    <div className="customer-care-container">
      <h2>Customer Care</h2>
      <textarea
        className="query-input"
        placeholder="Enter your query here..."
        value={query}
        onChange={(e) => setQuery(e.target.value)}
      ></textarea>
      <button className="submit-btn" onClick={handleQuerySubmit}>Submit</button>
      {response && <p className="response-message">{response}</p>}
    </div>
  );
};

export default CustomerCare;