// import React, { useState, useEffect } from 'react';
// import { Form, Button, Container, Row, Col, Card, Alert } from 'react-bootstrap';
// import './BookingForm.css';

// const BookingForm = () => {
//     const [formData, setFormData] = useState({
//         rentalDate: '',
//         rentalTime: '',
//         returnDate: '',
//         returnTime: '',
//         pickupLocation: '',
//         pickupState: '',
//         pickupCity: '',
//         returnLocation: '',
//         returnState: '',
//         returnCity: '',
//         returnToDifferentLocation: false,
//     });

//     const [airportCodes, setAirportCodes] = useState([]);
//     const [error, setError] = useState('');

//     useEffect(() => {
//         const fetchAirports = async () => {
//             try {
//                 const response = await fetch('http://localhost:8080/airport');
//                 if (!response.ok) throw new Error('Failed to fetch airport codes');
//                 const data = await response.json();
//                 setAirportCodes(data);
//             } catch (error) {
//                 console.error('Error fetching airport codes:', error);
//                 setError('Failed to fetch airport codes. Please try again later.');
//             }
//         };

//         fetchAirports();
//     }, []);

//     const handleChange = (e) => {
//         const { name, value, type, checked } = e.target;
//         setFormData(prevState => ({
//             ...prevState,
//             [name]: type === 'checkbox' ? checked : value
//         }));
//     };

//     const handleAirportSelection = (e, locationType) => {
//         const { value } = e.target;
//         const selectedAirport = airportCodes.find(airport => airport.airportCode === value);
//         if (selectedAirport) {
//             setFormData(prevState => ({
//                 ...prevState,
//                 [`${locationType}Location`]: value,
//                 [`${locationType}City`]: selectedAirport.cityId.cityName,
//                 [`${locationType}State`]: selectedAirport.stateId.stateName,
//             }));
//         }
//     };

//     const handleSubmit = async (e) => {
//         e.preventDefault();
//         try {
//             sessionStorage.setItem('bookingData', JSON.stringify(formData));
//             const response = await fetch('http://localhost:8080/api/addbooking', {
//                 method: 'POST',
//                 headers: { 'Content-Type': 'application/json' },
//                 body: JSON.stringify(formData)
//             });
//             if (!response.ok) throw new Error('Booking failed');
//             console.log('Booking successful');
//             window.location.href = '/HubSelectionForm';
//         } catch (error) {
//             console.error('Error submitting form:', error);
//             setError('Booking failed. Please try again.');
//         }
//     };

//     return (
//         <Container className="container">
//             <Card className="card">
//                 <Card.Body className="card-body">
//                     <h3>Book Your Ride</h3>
//                     {error && <Alert variant="danger">{error}</Alert>}
//                     <Form onSubmit={handleSubmit}>
//                         <Row>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Rental Date</Form.Label>
//                                     <Form.Control type="date" name="rentalDate" value={formData.rentalDate} onChange={handleChange} required />
//                                 </Form.Group>
//                             </Col>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Rental Time</Form.Label>
//                                     <Form.Control type="time" name="rentalTime" value={formData.rentalTime} onChange={handleChange} required />
//                                 </Form.Group>
//                             </Col>
//                         </Row>

//                         <Row>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Return Date</Form.Label>
//                                     <Form.Control type="date" name="returnDate" value={formData.returnDate} onChange={handleChange} required />
//                                 </Form.Group>
//                             </Col>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Return Time</Form.Label>
//                                     <Form.Control type="time" name="returnTime" value={formData.returnTime} onChange={handleChange} required />
//                                 </Form.Group>
//                             </Col>
//                         </Row>

//                         <Form.Group className="form-group">
//                             <Form.Label className="form-label">Pickup Location</Form.Label>
//                             <Form.Select name="pickupLocation" onChange={(e) => handleAirportSelection(e, 'pickup')} required>
//                                 <option value="">Select Airport</option>
//                                 {airportCodes.map(airport => (
//                                     <option key={airport.airportId} value={airport.airportCode}>{airport.airportName} ({airport.airportCode})</option>
//                                 ))}
//                             </Form.Select>
//                         </Form.Group>

//                         <Row>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Pickup State</Form.Label>
//                                     <Form.Control type="text" name="pickupState" value={formData.pickupState} onChange={handleChange} readOnly />
//                                 </Form.Group>
//                             </Col>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Pickup City</Form.Label>
//                                     <Form.Control type="text" name="pickupCity" value={formData.pickupCity} onChange={handleChange} readOnly />
//                                 </Form.Group>
//                             </Col>
//                         </Row>

//                         <Form.Group className="form-group">
//                             <Form.Label className="form-label">Return Location</Form.Label>
//                             <Form.Select name="returnLocation" onChange={(e) => handleAirportSelection(e, 'return')} required>
//                                 <option value="">Select Airport</option>
//                                 {airportCodes.map(airport => (
//                                     <option key={airport.airportId} value={airport.airportCode}>{airport.airportName} ({airport.airportCode})</option>
//                                 ))}
//                             </Form.Select>
//                         </Form.Group>

//                         <Row>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Return State</Form.Label>
//                                     <Form.Control type="text" name="returnState" value={formData.returnState} onChange={handleChange} readOnly />
//                                 </Form.Group>
//                             </Col>
//                             <Col md={6}>
//                                 <Form.Group className="form-group">
//                                     <Form.Label className="form-label">Return City</Form.Label>
//                                     <Form.Control type="text" name="returnCity" value={formData.returnCity} onChange={handleChange} readOnly />
//                                 </Form.Group>
//                             </Col>
//                         </Row>

//                         <Form.Group className="form-group">
//                             <Form.Check type="checkbox" name="returnToDifferentLocation" checked={formData.returnToDifferentLocation} onChange={handleChange} label="Return to a different location?" />
//                         </Form.Group>

//                         <Button variant="dark" type="submit" className="button">Confirm Booking</Button>
//                     </Form>
//                 </Card.Body>
//             </Card>
//         </Container>
//     );
// };

// export default BookingForm;