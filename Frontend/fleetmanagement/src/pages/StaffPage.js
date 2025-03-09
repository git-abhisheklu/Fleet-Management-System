// import React, { useEffect } from 'react';
// import { useNavigate } from 'react-router-dom';
// import './StaffPage.css'; 

// const StaffPage = () => {
//   const navigate = useNavigate();

//   useEffect(() => {
//     const isAuthenticated = sessionStorage.getItem('isAuthenticated');
//     if (!isAuthenticated) {
//       navigate('/StaffLogin'); // Redirect to login page if not authenticated
//     }
//   }, [navigate]);

//   const handleBooking = () => {
//     navigate("/ReservationByStaff", { state: { isStaff: true } });
//   };

//   const handleReturn = () => {
//     navigate("/Return");
//   };

//   const handleHandover = () => {
//     navigate("/HandOverDetails");
//   };

//   const handleCancel = () => {
//     const shouldCancel = window.confirm("Are you sure you want to cancel?");
//     if (shouldCancel) {
//       navigate("/CancleBookingByStaff");
//     }
//   };

//   return (
//     <div className="container-fluid text-center staff-page">
//       <h2 className="staff-page-heading">Staff Page</h2>
//       <div className="button-group" role="group" aria-label="Basic example">
//         <button className="btn btn-outline-success me-4 mb-2" onClick={handleBooking}>Booking</button>
//         <button className="btn btn-outline-success me-4 mb-2" onClick={handleHandover}>Handover</button>
//         <button className="btn btn-outline-success me-4 mb-2" onClick={handleReturn}>Return</button>
//         <button className="btn btn-outline-danger me-4 mb-2" onClick={handleCancel}>Cancel</button>
//       </div>
//     </div>
//   );
// };

// export default StaffPage;