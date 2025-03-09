import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, Button, Row, Col } from 'react-bootstrap';
import Navbar from '../Components/Navbar';
import Footer2 from '../Components/Footer2';
import '../pages/CustomerInfo.css';

const CustomerForm = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        addressLine1: '',
        addressLine2: '',
        homePhone: '',
        email: '',
        city: '',
        pincode: '',
        phoneNumber: '',
        mobileNumber: '',
        creditCardType: '',
        creditCardNumber: '',
        drivingLicenseNumber: '',
        idpNumber: '',
        issuedByDL: '',
        validThroughDL: '',
        passportNumber: '',
        passportValidThrough: '',
        passportIssuedBy: '',
        passportValidFrom: '',
        passportIssueDate: '',
        dateOfBirth: '',
        password: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const isUser18OrOlder = (dateOfBirth) => {
        const today = new Date();
        const birthDate = new Date(dateOfBirth);
        const age = today.getFullYear() - birthDate.getFullYear();
        const monthDifference = today.getMonth() - birthDate.getMonth();

        if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
            return age - 1 >= 18; // Adjust age if birthday hasn't occurred yet this year
        }
        return age >= 18;
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Check if the user is at least 18 years old
        if (!isUser18OrOlder(formData.dateOfBirth)) {
            alert('Age should be greater than 18.');
            return; // Prevent form submission
        }

        try {
            const response = await fetch('http://localhost:8080/api/customers', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });

            if (response.ok) {
                console.log('Customer data submitted successfully');
                sessionStorage.setItem('formData', JSON.stringify(formData));
                localStorage.setItem('email', formData.email);
                navigate('/BookingDetail');
                setFormData({
                    firstName: '',
                    lastName: '',
                    addressLine1: '',
                    addressLine2: '',
                    homePhone: '',
                    email: '',
                    city: '',
                    pincode: '',
                    phoneNumber: '',
                    mobileNumber: '',
                    creditCardType: '',
                    creditCardNumber: '',
                    drivingLicenseNumber: '',
                    idpNumber: '',
                    issuedByDL: '',
                    validThroughDL: '',
                    passportNumber: '',
                    passportValidThrough: '',
                    passportIssuedBy: '',
                    passportValidFrom: '',
                    passportIssueDate: '',
                    dateOfBirth: '',
                    password: ''
                });
            } else {
                console.error('Failed to submit customer data');
            }
        } catch (error) {
            console.error('Error submitting customer data:', error);
        }
    };

    return (
        <>
            <Navbar />
            <div className="customer-form-background">
                <Row className="justify-content-center mt-4">
                    <Col md={6} className="customer-form-container">
                        <Form onSubmit={handleSubmit} className="customer-form">
                            <h2 className="form-title">Customer Information</h2>

                            {[
                                { label: 'First Name', name: 'firstName' },
                                { label: 'Last Name', name: 'lastName' },
                                { label: 'Address Line 1', name: 'addressLine1' },
                                { label: 'Address Line 2', name: 'addressLine2' },
                                { label: 'Home Phone', name: 'homePhone' },
                                { label: 'Email', name: 'email', type: 'email' },
                                { label: 'City', name: 'city' },
                                { label: 'Pincode', name: 'pincode' },
                                { label: 'Phone Number', name: 'phoneNumber' },
                                { label: 'Mobile Number', name: 'mobileNumber' },
                                { label: 'Driving License Number', name: 'drivingLicenseNumber' },
                                { label: 'IDP Number', name: 'idpNumber' },
                                { label: 'Valid Through (DL)', name: 'validThroughDL', type: 'date' },
                                { label: 'Passport Number', name: 'passportNumber' },
                                { label: 'Passport Valid Through', name: 'passportValidThrough', type: 'date' },
                                { label: 'Passport Issued By', name: 'passportIssuedBy' },
                                { label: 'Passport Issue Date', name: 'passportIssueDate', type: 'date' },
                                { label: 'Date of Birth', name: 'dateOfBirth', type: 'date' }
                            ].map(({ label, name, type = 'text' }) => (
                                <Form.Group controlId={name} className="form-group" key={name}>
                                    <Form.Label>{label}:</Form.Label>
                                    <Form.Control type={type} name={name} value={formData[name]} onChange={handleChange} required />
                                </Form.Group>
                            ))}

                            <Button variant="primary" type="submit" className="submit-btn">Submit</Button>
                        </Form>
                    </Col>
                </Row>
            </div>
            <Footer2 />
        </>
    );
};

export default CustomerForm;