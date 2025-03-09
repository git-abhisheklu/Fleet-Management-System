import React, { useEffect, useState } from "react";

const BookingList = () => {
  const [bookings, setBookings] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch("http://localhost:8080/api/bookings")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to fetch bookings");
        }
        return response.json();
      })
      .then((data) => {
        setBookings(data);
        setLoading(false);
      })
      .catch((error) => {
        setError(error.message);
        setLoading(false);
      });
  }, []);

  const handleApprove = (bookingId) => {
    const confirmApproval = window.confirm("Are you sure you want to approve this booking?");
    if (confirmApproval) {
      alert(`Booking ${bookingId} has been approved!`);
      // Implement API call to update booking status if needed
    }
  };

  const handleDelete = (bookingId) => {
    fetch(`http://localhost:8080/api/deletebooking/${bookingId}`, {
      method: "DELETE",
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error("Failed to delete booking");
        }
        setBookings(bookings.filter((booking) => booking.bookingId !== bookingId));
      })
      .catch((error) => {
        console.error("Error deleting booking:", error);
      });
  };

  if (loading) return <p>Loading bookings...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="p-4">
      <h2 className="text-xl font-bold mb-4">Bookings</h2>
      <table className="min-w-full bg-white border border-gray-200">
        <thead>
          <tr className="bg-gray-100">
            <th className="border px-4 py-2">Booking ID</th>
            <th className="border px-4 py-2">Customer Name</th>
            <th className="border px-4 py-2">Email</th>
            <th className="border px-4 py-2">Booking Date</th>
            <th className="border px-4 py-2">Start Date</th>
            <th className="border px-4 py-2">End Date</th>
            <th className="border px-4 py-2">Daily Rate</th>
            <th className="border px-4 py-2">Weekly Rate</th>
            <th className="border px-4 py-2">Monthly Rate</th>
            <th className="border px-4 py-2">Pickup Hub</th>
            <th className="border px-4 py-2">Return Hub</th>
            <th className="border px-4 py-2">Booking Details</th>
            <th className="border px-4 py-2">Actions</th>
          </tr>
        </thead>
        <tbody>
          {bookings.map((booking) => (
            <tr key={booking.bookingId}>
              <td className="border px-4 py-2">{booking.bookingId}</td>
              <td className="border px-4 py-2">{booking.firstname} {booking.lastname}</td>
              <td className="border px-4 py-2">{booking.emailId}</td>
              <td className="border px-4 py-2">{booking.bookingdate}</td>
              <td className="border px-4 py-2">{booking.startdate}</td>
              <td className="border px-4 py-2">{booking.enddate}</td>
              <td className="border px-4 py-2">{booking.dailyrate}</td>
              <td className="border px-4 py-2">{booking.weeklyrate}</td>
              <td className="border px-4 py-2">{booking.monthlyrate}</td>
              <td className="border px-4 py-2">{booking.pickup_hubAddress}</td>
              <td className="border px-4 py-2">{booking.return_hubAddress}</td>
              <td className="border px-4 py-2">
                <ul>
                  {booking.bookingDetails.map((detail) => (
                    <li key={detail.bookingDetailId}>
                      Addon ID: {detail.addonId}, Rate: {detail.addonRate}
                    </li>
                  ))}
                </ul>
              </td>
              <td className="border px-4 py-2">
                <button
                  className="bg-green-500 text-white px-2 py-1 rounded mr-2"
                  onClick={() => handleApprove(booking.bookingId)}
                >
                  Approve
                </button>
                <button
                  className="bg-red-500 text-white px-2 py-1 rounded"
                  onClick={() => handleDelete(booking.bookingId)}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BookingList;
