import React, { useState, useEffect } from 'react';
import { Container, Row, Col, Form, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import staff from '../assets/staff.png'; // Import the background image
import '../pages/ReservationByStaff.css'; // Import the CSS file

const StaffReservationForm = () => {
  const navigate = useNavigate();

  const getCurrentDate = () => new Date().toISOString().split('T')[0];

  const getCurrentTime = () => {
    const now = new Date();
    return now.toTimeString().slice(0, 5); // Format: HH:MM
  };

  const [formData, setFormData] = useState({
    rentalDate: getCurrentDate(),
    rentalTime: getCurrentTime(),
    rentalTimePeriod: new Date().getHours() >= 12 ? 'PM' : 'AM',
    returnDate: '',
    returnTime: '',
    returnTimePeriod: 'AM',
    hubLocation: 'Mumbai',
    airportCode: 'BOM',
  });

  useEffect(() => {
    setFormData((prevData) => ({
      ...prevData,
      returnDate: getCurrentDate(), // Set return date default to today
    }));
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;

    setFormData((prevData) => {
      let updatedData = { ...prevData, [name]: value };

      if (name === 'rentalDate' && updatedData.returnDate < value) {
        updatedData.returnDate = value; // Prevent selecting past return date
      }

      return updatedData;
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!formData.returnDate || !formData.returnTime) {
      alert('Please fill in all required fields.');
      return;
    }

    if (formData.returnDate < formData.rentalDate) {
      alert('Return date must be after the rental date.');
      return;
    }

    navigate('/VehicleSelection', { state: { formData } });
  };

  return (
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
    <Container className="reservation-container">
      <h2 className="reservation-title">Reservation by Staff</h2>
      <Form onSubmit={handleSubmit}>
        <Row>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Rental Date</Form.Label>
              <Form.Control
                type="date"
                name="rentalDate"
                value={formData.rentalDate}
                readOnly
              />
            </Form.Group>
          </Col>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Rental Time</Form.Label>
              <Form.Control
                type="time"
                name="rentalTime"
                value={formData.rentalTime}
                readOnly
              />
            </Form.Group>
          </Col>
        </Row>

        <Row>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Return Date</Form.Label>
              <Form.Control
                type="date"
                name="returnDate"
                value={formData.returnDate}
                min={formData.rentalDate} // Ensures return date is not before rental date
                onChange={handleChange}
                required
              />
            </Form.Group>
          </Col>
          <Col md={6}>
            <Form.Group className="mb-3">
              <Form.Label>Return Time</Form.Label>
              <Form.Control
                type="time"
                name="returnTime"
                value={formData.returnTime}
                onChange={handleChange}
                required
              />
            </Form.Group>
          </Col>
        </Row>

        <Form.Group className="mb-3">
          <Form.Label>Hub Location</Form.Label>
          <Form.Control
            type="text"
            name="hubLocation"
            value={formData.hubLocation}
            readOnly
          />
        </Form.Group>

        <Button variant="primary" type="submit" className="submit-button">
          Continue Booking
        </Button>
      </Form>
    </Container>
    </div>
  );
};

export default StaffReservationForm;
