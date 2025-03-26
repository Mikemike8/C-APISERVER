import React, { useState, useEffect } from 'react';

const ItemList = () => {
  const [items, setItems] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5106/WeatherForecast')
      .then((response) => response.json())
      .then((data) => setItems(data));  // Store fetched data in state
  }, []);  // Empty dependency array ensures this runs once on mount

  return (
    <ul>
      {items.map(item => (
        <li key={item.date}>{item.summary}</li>  // Display each item once loaded
      ))}
    </ul>
  );
};

export default ItemList;
