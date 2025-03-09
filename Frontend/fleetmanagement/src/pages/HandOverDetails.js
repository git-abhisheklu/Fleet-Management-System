import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom"; // Import useNavigate
import Navbar from '../Components/Navbar';
import Footer2 from '../Components/Footer2';
import staff from "../assets/staff.png";
import './HandOverDetails.css';

function HandOverDetails() {
  const [email, setEmail] = useState("");
  const [bookingDetails, setBookingDetails] = useState([]);
  const [error, setError] = useState(null);
  const [carTypes, setCarTypes] = useState([]);
  const [selectedCarType, setSelectedCarType] = useState("");
  const [availableCars, setAvailableCars] = useState([]);
  const [selectedCar, setSelectedCar] = useState(null); // State for selected car
  const [selectedCarDetails, setSelectedCarDetails] = useState([]);

  const navigate = useNavigate(); // Initialize useNavigate

  // Fetch Booking Details by Email
  const handleFetchBookingDetails = async () => {
    setError(null);
    setBookingDetails([]);

    try {
      const response = await fetch(`http://localhost:8080/api/booking/email/${email}`);
      if (!response.ok) {
        throw new Error(`Failed to fetch booking details: ${response.statusText}`);
      }
      const data = await response.json();
      setBookingDetails(data);
    } catch (err) {
      setError(err.message);
    }
  };

  // Fetch Car Types on Component Mount
  useEffect(() => {
    const fetchCarTypes = async () => {
      try {
        const response = await fetch("http://localhost:8080/api/cartype/all");
        if (!response.ok) {
          throw new Error("Failed to fetch car types");
        }
        const data = await response.json();
        setCarTypes(data);
      } catch (error) {
        console.error(error.message);
      }
    };

    fetchCarTypes();
  }, []);

  // Fetch Available Cars based on Selected Car Type
  useEffect(() => {
    if (selectedCarType) {
      const fetchAvailableCars = async () => {
        try {
          const response = await fetch(`http://localhost:8080/cars/type/${selectedCarType}`);
          if (!response.ok) {
            throw new Error("Failed to fetch available cars");
          }
          const data = await response.json();
          setAvailableCars(data);
        } catch (error) {
          console.error(error.message);
        }
      };

      fetchAvailableCars();
    } else {
      setAvailableCars([]);
    }
  }, [selectedCarType]);

  // Handle Car Selection
  const handleCarSelection = (carId) => {
    setSelectedCar(carId === selectedCar ? null : carId); // Toggle selection
  };

  // Handle Done Button Click
  const handleDone = () => {
    const details = availableCars.filter((car) => car.carId === selectedCar);
    setSelectedCarDetails(details);
  };

  // Handle Cancel Button Click
  const handleCancel = () => {
    navigate("/"); // Redirect to the home page
  };

  return (
    <>
      <Navbar />
      <div
        style={{
          backgroundImage: `url(${staff})`,
          backgroundSize: "cover",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
          minHeight: "100vh",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "center",
          padding: "20px",
          width: "100%",
        }}
      >
        <div className="container">
          {/* Booking Details Section */}
          <h1 className="heading">Booking Details</h1>

          <div className="form-group">
            <label htmlFor="email" className="form-label">
              Email Address:
            </label>
            <input
              id="email"
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="form-input"
            />
          </div>

          <button onClick={handleFetchBookingDetails} className="button-primary">
            Fetch Booking Details
          </button>

          {error && <div className="error-message">Error: {error}</div>}

          {bookingDetails.length > 0 ? (
            <div className="booking-details">
              <h2 className="subheading">Booking Details</h2>
              {bookingDetails.map((booking, index) => (
                <div key={index} className="card">
                  <p>
                    <strong>Full Name:</strong> {`${booking.firstname} ${booking.lastname}`}
                  </p>
                  <p>
                    <strong>Email ID:</strong> {booking.emailId}
                  </p>
                  <p>
                    <strong>Booking Date:</strong> {booking.bookingdate}
                  </p>
                </div>
              ))}
            </div>
          ) : (
            <p className="no-data">No bookings found for this email.</p>
          )}

          {/* Car Type Selector Section */}
          <div className="car-type-selector">
            <h1 className="heading">Car Type Selector</h1>

            {/* Car Type Dropdown */}
            <div className="form-group">
              <label htmlFor="carType" className="form-label">
                Select Car Type:
              </label>
              <select
                id="carType"
                value={selectedCarType}
                onChange={(e) => setSelectedCarType(e.target.value)}
                className="form-input"
              >
                <option value="">-- Select a Car Type --</option>
                {carTypes.map((carType) => (
                  <option key={carType.cartypeId} value={carType.cartypeId}>
                    {carType.carTypeName}
                  </option>
                ))}
              </select>
            </div>

            {/* Available Cars */}
            {availableCars.length > 0 ? (
              <div className="car-grid">
                {availableCars.map((car) => (
                  <div
                    key={car.carId}
                    className={`car-card ${car.isAvailable === "Y" ? "available" : "unavailable"}`}
                  >
                    <input
                      type="checkbox"
                      checked={selectedCar === car.carId}
                      onChange={() => handleCarSelection(car.carId)}
                      className="car-checkbox"
                      disabled={car.isAvailable !== "Y"} // Disable if the car is not available
                    />
                    <strong>Car Name:</strong> {car.carName} <br />
                    <strong>Number Plate:</strong> {car.numberPlate} <br />
                    <strong>Fuel Status:</strong> {car.fuelStatus} <br />
                    <strong>Available:</strong> {car.isAvailable === "Y" ? "Yes" : "No"}
                  </div>
                ))}
              </div>
            ) : selectedCarType ? (
              <p className="no-data">No cars available for the selected type.</p>
            ) : null}

            {/* Buttons Section */}
            <div className="button-group">
              <button onClick={handleDone} className="button-primary">
                Done
              </button>
              <button onClick={handleCancel} className="button-secondary">
                Cancel
              </button>
            </div>

            {/* Selected Car Details */}
            {selectedCarDetails.length > 0 && (
              <div className="selected-cars">
                <h2 className="subheading">Selected Cars</h2>
                {selectedCarDetails.map((car) => (
                  <div key={car.carId} className="card">
                    <strong>Car Name:</strong> {car.carName}
                    <br />
                    <strong>Number Plate:</strong> {car.numberPlate} <br />
                    <strong>Fuel Status:</strong> {car.fuelStatus} <br />
                    <strong>Available:</strong> {car.isAvailable === "Y" ? "Yes" : "No"}
                  </div>
                ))}
              </div>
            )}
          </div>
        </div>
      </div>
      <Footer2 />
    </>
  );
}

export default HandOverDetails;