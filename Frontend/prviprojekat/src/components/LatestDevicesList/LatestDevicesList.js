import React, { useState, useEffect } from 'react';
import './LatestDevicesList.css'; // Stilovi za LatestDevicesList

const LatestDevicesList = () => {
  const [latestDevices, setLatestDevices] = useState([]);

  useEffect(() => {
    fetchLatestDevices();
  }, []);

  const fetchLatestDevices = async () => {
    try {
      const response = await fetch('/api/latestDevices?Limit10'); // Zamijenite sa pravim putanjama do vašeg API endpointa
      const data = await response.json();
      setLatestDevices(data);
    } catch (error) {
      console.error('Error fetching latest devices:', error);
    }
  };

  return (
    <div className="latest-devices-list">
      <h2>Najnoviji uređaji</h2>
      <ul>
        {latestDevices.map((device, index) => (
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

export default LatestDevicesList;
