import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css";
import Navbar from "../Components/Navbar";
import Footer2 from "../Components/Footer2";
import "../pages/VehicleSelection.css"; 

function VehicleSelection() {
  const [vehicles, setVehicles] = useState([]);
  const [selectedVehicle, setSelectedVehicle] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    async function fetchVehicles() {
      try {
        const response = await fetch('http://localhost:8080/api/cartype/all');
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();

        const formattedData = data.map(vehicle => ({
          id: vehicle.cartypeId,
          image: vehicle.imagePath,
          type: vehicle.carTypeName,
          dailyRate: vehicle.dailyRate,
          weeklyRate: vehicle.weeklyRate,
          monthlyRate: vehicle.monthlyRate
        }));

        setVehicles(formattedData);
      } catch (err) {
        setError(err);
        console.error("Error fetching vehicles:", err);
      } finally {
        setLoading(false);
      }
    }

    fetchVehicles();
  }, []);

  const handleSelect = (vehicle) => {
    setSelectedVehicle(vehicle);
  };

  const handleContinueBooking = () => {
    if (selectedVehicle) {
      localStorage.setItem('dailyrate', selectedVehicle.dailyRate);
      localStorage.setItem('weeklyrate', selectedVehicle.weeklyRate);
      localStorage.setItem('monthlyrate', selectedVehicle.monthlyRate);
      localStorage.setItem('selectedCarId', selectedVehicle.id);
      localStorage.setItem('selectedCarTypeId', selectedVehicle.typeId);
      console.log(selectedVehicle.type);
      navigate('/Addon', { state: { selectedVehicle: selectedVehicle } });
    } else {
      alert("Please select a vehicle.");
    }
  };

  if (loading) {
    return <div className="loading">Loading vehicles...</div>;
  }

  if (error) {
    return <div className="error">Error: {error.message}</div>;
  }

  return (
    <>
      <Navbar />
      <div className="vehicle-selection-container">
        <h2 className="title">Select Your Vehicle</h2>
        <div className="table-container">
          <table className="vehicle-table">
            <thead>
              <tr>
                <th>Car Class</th>
                <th>Car Type</th>
                <th>Base Rate (Daily)</th>
                <th>Base Rate (Weekly)</th>
                <th>Base Rate (Monthly)</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {vehicles.map(vehicle => (
                <tr key={vehicle.id} className={selectedVehicle?.id === vehicle.id ? "selected" : ""}>
                  <td>
                    <img src={vehicle.image} alt={vehicle.type} className="car-image" />
                  </td>
                  <td>{vehicle.type}</td>
                  <td>${vehicle.dailyRate}</td>
                  <td>${vehicle.weeklyRate}</td>
                  <td>${vehicle.monthlyRate}</td>
                  <td>
                    <button className="select-btn" onClick={() => handleSelect(vehicle)}>Select</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        <div className="button-container">
          <button className="continue-btn" onClick={handleContinueBooking}>Continue Booking</button>
          <button className="cancel-btn" onClick={() => navigate('/')}>Cancel</button>
        </div>
      </div>
      <Footer2 />
    </>
  );
}

export default VehicleSelection;