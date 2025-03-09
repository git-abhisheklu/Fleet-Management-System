import React, { useState } from "react";
import "./ModifyCancel.css";
import { useNavigate } from "react-router-dom";

const ModifyCancel = ({ bookingId }) => {
  const [cancelReason, setCancelReason] = useState("");
  const [showReasonInput, setShowReasonInput] = useState(false);
  const navigate = useNavigate();

  const handleModify = () => {
    navigate("/Customerinfo");
  };

  const handleCancel = async () => {
    if (!showReasonInput) {
      setShowReasonInput(true);
      return;
    }

    if (cancelReason.trim() === "") {
      alert("Please enter a reason for cancellation.");
      return;
    }

    try {
      const response = await fetch(
        `http://localhost:8080/api/bookingdetails/${bookingId}`,
        {
          method: "DELETE",
        }
      );
      if (response.ok) {
        alert("Booking cancelled successfully.");
        setCancelReason("");
        setShowReasonInput(false);
      } else {
        alert("Failed to cancel booking.");
      }
    } catch (error) {
      console.error("Error cancelling booking:", error);
    }
  };

  return (
    <div className="modify-cancel-container">
      <button className="modify-btn" onClick={handleModify}>Modify</button>
      <button className="cancel-btn" onClick={handleCancel}>Cancel</button>
      {showReasonInput && (
        <div className="cancel-reason-container">
          <textarea
            className="cancel-reason"
            placeholder="Enter reason for cancellation..."
            value={cancelReason}
            onChange={(e) => setCancelReason(e.target.value)}
          ></textarea>
          <button className="confirm-cancel-btn" onClick={handleCancel}>Confirm Cancel</button>
        </div>
      )}
    </div>
  );
};

export default ModifyCancel;
