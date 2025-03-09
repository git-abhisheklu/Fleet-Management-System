import React, { useState } from "react";
import "../pages/Return.css"
// import handover from "../assets/handover.png";
import book from "../assets/book.png";

function HandOverDetails() {
  const [email, setEmail] = useState("");
  const [bookingId, setBookingId] = useState("");
  const [bookingDetails, setBookingDetails] = useState([]);
  const [fuelStatus, setFuelStatus] = useState(""); // State for fuel status
  const [error, setError] = useState(null);

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

      console.log("API Response:", data); // Debugging Line

      setBookingDetails(data);
      if (data.length > 0) {
        setBookingId(data[0].bookingId); // Automatically setting bookingId for download
      }
    } catch (err) {
      console.error("Fetch Error:", err); // Debugging Line
      setError(err.message);
    }
  };

  // Download PDF from Backend
  const handleDownloadPDF = async () => {
    if (!bookingId) {
      setError("No valid booking ID found for download.");
      console.error("Booking ID is missing.");
      return;
    }

    try {
      console.log(`Downloading PDF for Booking ID: ${bookingId}`); // Debugging Line
      const response = await fetch(`http://localhost:8080/invoice/generate/${bookingId}`);
      
      if (!response.ok) {
        throw new Error(`Failed to download PDF: ${response.statusText}`);
      }

      const blob = await response.blob();
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = `booking-${bookingId}.pdf`;
      document.body.appendChild(a);
      a.click();
      a.remove();
      console.log("PDF Download Successful!"); // Debugging Line
    } catch (err) {
      console.error("PDF Download Error:", err); // Debugging Line
      setError(err.message);
    }
  };

  const getCurrentDate = () => {
    const today = new Date();
    return today.toISOString().split('T')[0]; // Format as YYYY-MM-DD
  };

  return (
    <div
        style={{
          backgroundImage: `url(${book})`,
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
    <div className="p-4">
      {/* Booking Details Section */}
      <h1 className="text-2xl font-bold mb-4">Booking Details</h1>

      <div className="mb-4">
        <label htmlFor="email" className="block text-sm font-medium">
          Email Address:
        </label>
        <input
          id="email"
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="border border-gray-300 rounded p-2 w-full"
        />
      </div>

      <button
        onClick={handleFetchBookingDetails}
        className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600"
      >
        Fetch Booking Details
      </button>

      {error && <div className="mt-4 text-red-500">Error: {error}</div>}

      {bookingDetails.length > 0 ? (
        <div className="mt-4">
          <h2 className="text-xl font-semibold mb-2">Booking Details</h2>
          {bookingDetails.map((booking, index) => (
            <div key={index} className="mb-4 border p-4 rounded shadow">
              <p>
                <strong>Full Name:</strong> {`${booking.firstname} ${booking.lastname}`}
              </p>
              <p>
                <strong>Email ID:</strong> {booking.emailId}
              </p>
              <p>
                <strong>Car Type:</strong> {booking.cartype?.carTypeName ?? "Sedan"}
              </p>
              <p>
                <strong>Car ID:</strong> {booking.bookingDetails.length =2}
              </p>
              <p>
                <strong>Start Date:</strong> {booking.startdate}
              </p>
              <p>
                <strong>End Date:</strong> {getCurrentDate()}
              </p>
              <p>
                <strong>Fuel Status:</strong>
                <select
                  value={fuelStatus}
                  onChange={(e) => setFuelStatus(e.target.value)}
                  className="border border-gray-300 rounded p-2 ml-2"
                >
                  <option value="">Select Fuel Status</option>
                  <option value="Full">Full</option>
                  <option value="Three Quarters">Three Quarters</option>
                  <option value="Half">Half</option>
                  <option value="Quarter">Quarter</option>
                  <option value="Empty">Empty</option>
                </select>
              </p>
            </div>
          ))}

          <button
            onClick={handleDownloadPDF}
            className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600 mt-4"
          >
            Download PDF
          </button>
        </div>
      ) : (
        <p>No bookings found for this email.</p>
      )}
    </div>
    </div>
  );
}

export default HandOverDetails;