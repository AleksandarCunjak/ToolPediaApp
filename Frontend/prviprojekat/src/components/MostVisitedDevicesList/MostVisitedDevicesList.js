import React, { useState, useEffect } from 'react';
import './MostVisitedDevicesList.css'; // Stilovi za MostVisitedDevicesList

const MostVisitedDevicesList = () => {
  const [mostVisitedDevices, setMostVisitedDevices] = useState([]);

  useEffect(() => {
    fetchMostVisitedDevices();
  }, []);

  const fetchMostVisitedDevices = async () => {
    try {
      const response = await fetch('/api/mostVisitedDevices?limit=5'); // Zamijenite sa pravom putanjom i dodajte parametar za limitiranje rezultata
      const data = await response.json();
      setMostVisitedDevices(data);
    } catch (error) {
      console.error('Error fetching most visited devices:', error);
    }
  };

  return (
    <div className="most-visited-devices-list">
      <h2>Najposjećeniji uređaji</h2>
      <ul>
        {mostVisitedDevices.map((device, index) => (
          <li key={index}>
            <p>{device.name}</p>
            <p>{device.description}</p>
            {/* Dodajte ostale informacije o uređaju */}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default MostVisitedDevicesList;
