import React, { useEffect, useState } from "react";
import { Form, Button, Container, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import Navbar from "../Components/Navbar";
import Footer2 from "../Components/Footer2";
import "../pages/BookingDetail.css";

const BookingDetails = () => {
  const [customer, setCustomer] = useState(null);
  const [booking, setBooking] = useState(null);
  const [loading, setLoading] = useState(true);
  const [estimatedAmt, setEstimatedAmt] = useState(0);
  const navigate = useNavigate();
  const customerEmail = localStorage.getItem("email");

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      try {
        const customerResponse = await fetch(
          `http://localhost:8080/api/customers/email/${customerEmail}`
        );
        if (!customerResponse.ok) {
          throw new Error("Failed to fetch customer data");
        }
        const customerData = await customerResponse.json();
        setCustomer(customerData);
      } catch (error) {
        console.error("Error fetching customer data:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [customerEmail]);

  useEffect(() => {
    calculateEstimatedAmount();
  }, []);

  const calculateEstimatedAmount = () => {
    const monthlyRate = parseFloat(localStorage.getItem("monthlyrate")) || 0;
    const dailyRate = parseFloat(localStorage.getItem("dailyrate")) || 0;
    const weeklyRate = parseFloat(localStorage.getItem("weeklyrate")) || 0;

    const start = new Date(localStorage.getItem("pickup date"));
    const end = new Date(localStorage.getItem("return date"));

    if (isNaN(start.getTime()) || isNaN(end.getTime())) {
      console.error("Invalid date range");
      return;
    }

    const totalDays = Math.ceil((end - start) / (1000 * 60 * 60 * 24));
    let totalCost = 0;
    if (totalDays >= 30) {
      let months = Math.floor(totalDays / 30);
      let remainingDays = totalDays % 30;
      totalCost = months * monthlyRate + remainingDays * dailyRate;
    } else if (totalDays >= 7) {
      let weeks = Math.floor(totalDays / 7);
      let remainingDays = totalDays % 7;
      totalCost = weeks * weeklyRate + remainingDays * dailyRate;
    } else {
      totalCost = totalDays * dailyRate;
    }

    setEstimatedAmt(totalCost);
  };

  const handleConfirm = async () => {
    if (!customer) {
      alert("Customer data is missing.");
      return;
    }

    const carTypeId = localStorage.getItem("selectedCarId");
    const carId = localStorage.getItem("selectedCarId");

    let cartype = null;
    let car = null;

    try {
      // Fetch car type details
      const cartypeResponse = await fetch(`http://localhost:8080/api/cartype/${carTypeId}`);
      if (cartypeResponse.ok) {
        cartype = await cartypeResponse.json();
      } else {
        console.error("Failed to fetch car type data.");
      }

      const carResponse = await fetch(`http://localhost:8080/cars/${carId}`);
      if (carResponse.ok) {
        car = await carResponse.json();
      } else {
        console.error("Failed to fetch car data.");
      }
    } catch (error) {
      console.error("Error fetching car or car type data:", error);
    }

    let bookingDetails = [];
    const storedBookingDetails = localStorage.getItem("bookingDetails");
    if (storedBookingDetails) {
      try {
        const parsedDetails = JSON.parse(storedBookingDetails);
        bookingDetails = parsedDetails.map((item, index) => ({
          detailId: index + 1, // Auto-generating an ID (if not provided)
          serviceName: item.serviceName || "",
          price: parseFloat(item.price) || 0,
        }));
      } catch (error) {
        console.error("Error parsing booking details from localStorage:", error);
      }
    }

    const bookingData = {
      bookingdate: new Date().toISOString().split("T")[0],
      firstname: customer.firstName || "",
      lastname: customer.lastName || "",
      startdate: localStorage.getItem("pickup date"),
      enddate: localStorage.getItem("return date"),
      emailId: customerEmail,
      address: "Andheri",
      state: "Maharashtra",
      pin: "400053",
      dailyrate: parseFloat(localStorage.getItem("dailyrate")) || 0,
      weeklyrate: parseFloat(localStorage.getItem("weeklyrate")) || 0,
      monthlyrate: parseFloat(localStorage.getItem("monthlyrate")) || 0,
      pickup_hubAddress: localStorage.getItem("pickup hubaddress"),
      return_hubAddress: localStorage.getItem("return hubaddress"),
      customer: customer
        ? {
            customerId: customer.customerId,
            firstName: customer.firstName,
            lastName: customer.lastName,
            email: customer.email,
            addressLine1: customer.addressLine1,
            addressLine2: customer.addressLine2,
            city: customer.city,
            pincode: customer.pincode,
            drivingLicenseNumber: customer.drivingLicenseNumber,
            idpNumber: customer.idpNumber,
            validThroughDL: customer.validThroughDL,
            passportNumber: customer.passportNumber,
            passportIssuedBy: customer.passportIssuedBy,
            passportValidFrom: customer.passportValidFrom,
            passportValidThrough: customer.passportValidThrough,
          }
        : null,
      car: car
        ? {
            carId: car.carId,
            carName: car.carName,
            carModel: car.carModel,
            carNumber: car.carNumber,
            seatingCapacity: car.seatingCapacity,
          }
        : null,
      cartype: cartype
        ? {
            cartypeId: cartype.cartypeId,
            typeName: cartype.typeName,
            dailyRate: cartype.dailyRate,
            weeklyRate: cartype.weeklyRate,
            monthlyRate: cartype.monthlyRate,
          }
        : null,
      bookingDetails: bookingDetails.length > 0 ? bookingDetails : null,
    };

    console.log("Booking data:", bookingData);

    try {
      const response = await fetch("http://localhost:8080/api/addbooking", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(bookingData),
      });

      if (response.ok) {
        alert("Booking confirmed successfully!");
        navigate("/");
      } else {
        const errorData = await response.json();
        console.error("Failed to confirm booking:", errorData);
        alert(`Failed to confirm booking: ${errorData.message}`);
      }
    } catch (error) {
      console.error("Error confirming booking:", error);
      alert("An error occurred while confirming booking.");
    }
  };

  const handleCancel = async () => {
    if (!booking || !booking.bookingId) {
      alert("No valid booking found!");
      return;
    }

    const confirmCancel = window.confirm("Are you sure you want to cancel this booking?");
    if (!confirmCancel) return;

    try {
      const response = await fetch(`http://localhost:8080/api/deletebooking/${booking.bookingId}`, {
        method: "DELETE",
      });

      if (response.ok) {
        alert("Booking canceled successfully!");
        setBooking(null);
        navigate("/Abhishek2");
      } else {
        alert("Failed to cancel booking. Please try again.");
      }
    } catch (error) {
      console.error("Error canceling booking:", error);
      alert("An error occurred while canceling the booking.");
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <>
      <Navbar />
      <Container className="booking-container">
        <h2 className="text-center mb-4">Booking Details</h2>

        <Row className="mb-3">
          <Col md={6}>
            <Form.Group>
              <Form.Label>Pick-up Date</Form.Label>
              <Form.Control type="text" defaultValue={localStorage.getItem("pickup date")} readOnly />
            </Form.Group>
            <Form.Group>
              <Form.Label>Pick-up Location</Form.Label>
              <Form.Control type="text" defaultValue={localStorage.getItem("pickup hubaddress")} readOnly />
            </Form.Group>
          </Col>
          <Col md={6}>
            <Form.Group>
              <Form.Label>Return Date</Form.Label>
              <Form.Control type="text" defaultValue={localStorage.getItem("return date")} readOnly />
            </Form.Group>
            <Form.Group>
              <Form.Label>Return Location</Form.Label>
              <Form.Control type="text" defaultValue={localStorage.getItem("return hubaddress")} readOnly />
            </Form.Group>
          </Col>
        </Row>

        <h4>Customer Details</h4>
        <Row className="mb-3">
          <Col md={6}>
            <Form.Group>
              <Form.Label>First Name</Form.Label>
              <Form.Control type="text" value={customer?.firstName || ""} readOnly />
            </Form.Group>
          </Col>
          <Col md={6}>
            <Form.Group>
              <Form.Label>Last Name</Form.Label>
              <Form.Control type="text" value={customer?.lastName || ""} readOnly />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col md={12}>
            <Form.Group>
              <Form.Label>Address</Form.Label>
              <Form.Control type="text" value={`${customer?.addressLine1 || ""}, ${customer?.addressLine2 || ""}`} readOnly />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col md={6}>
            <Form.Group>
              <Form.Label>Email</Form.Label>
              <Form.Control type="email" value={customer?.email || ""} readOnly />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>City</Form.Label>
              <Form.Control type="text" value={customer?.city || ""} readOnly />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>ZIP</Form.Label>
              <Form.Control type="text" value={customer?.pincode || ""} readOnly />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col md={6}>
            <Form.Group>
              <Form.Label>Driving License</Form.Label>
              <Form.Control type="text" value={customer?.drivingLicenseNumber || ""} readOnly disabled />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>IDP Number</Form.Label>
              <Form.Control type="text" value={customer?.idpNumber || ""} readOnly disabled />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>Valid Through</Form.Label>
              <Form.Control type="text" value={customer?.validThroughDL || ""} readOnly disabled />
            </Form.Group>
          </Col>
        </Row>

        <Row className="mb-3">
          <Col md={6}>
            <Form.Group>
              <Form.Label>Passport Number</Form.Label>
              <Form.Control type="text" value={customer?.passportNumber || ""} readOnly disabled />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>Issued By</Form.Label>
              <Form.Control type="text" value={customer?.passportIssuedBy || ""} readOnly disabled />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>Valid From</Form.Label>
              <Form.Control type="text" value={customer?.passportValidFrom || ""} readOnly disabled />
            </Form.Group>
          </Col>
          <Col md={3}>
            <Form.Group>
              <Form.Label>Valid Through</Form.Label>
              <Form.Control type="text" value={customer?.passportValidThrough || ""} readOnly disabled />
            </Form.Group>
          </Col>
        </Row>

        <h4>Estimated Amount</h4>
        <Row className="mb-3">
          <Col md={6}>
            <Form.Group>
              <Form.Label>Total Amount</Form.Label>
              <Form.Control type="text" value={`₹${estimatedAmt}`} readOnly />
            </Form.Group>
          </Col>
        </Row>

        <div className="text-center mt-4">
          <Button variant="primary" className="me-3" onClick={handleConfirm}>
            Confirm
          </Button>
          <Button variant="secondary" onClick={() => navigate("/Signup")}>
            Modify
          </Button>
          <Button variant="danger" onClick={handleCancel}>
            Cancel
          </Button>
        </div>
      </Container>
      <Footer2 />
    </>
  );
};

export default BookingDetails;