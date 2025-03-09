import React, { useState } from "react";
import { Form, Button, Container, Alert, Row, Col } from "react-bootstrap";
import { useNavigate } from "react-router-dom"; // Import useNavigate
import login from "../assets/login.png"; // Import the background image
import "./Signup.css"; 

function Signup() {
  const [email, setEmail] = useState("");
  const [username, setUsername] = useState("");
  const [lastName, setLastName] = useState("");
  const [password, setPassword] = useState("");
  const [rePassword, setRePassword] = useState("");
  const [message, setMessage] = useState("");
  const [error, setError] = useState("");

  const navigate = useNavigate(); // Initialize navigate

  const handleSubmit = async (e) => {
    e.preventDefault();
    setMessage("");
    setError("");

    if (password !== rePassword) {
      setError("Passwords do not match!");
      return;
    }

    const userData = {
      userName: username,
      lastName: lastName,
      email: email,
      password: password,
    };

    try {
      const response = await fetch("http://localhost:8080/auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userData),
      });

      if (response.ok) {
        setMessage("Signup successful! Redirecting to login...");
        setTimeout(() => {
          navigate("/LoginForm"); // Redirect to login page after signup
        }, 1000);
      } else {
        setError("Signup failed. Please try again.");
      }
    } catch (error) {
      setError("Error connecting to the server.");
    }
  };

  return (
    <>
      <div
        style={{
          backgroundImage: `url(${login})`,
          backgroundSize: "cover",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
          minHeight: "100vh",
          display: "flex",
          flexDirection: "column", // Corrected: Use camelCase
          alignItems: "center",
          justifyContent: "center",
          padding: "20px",
          width: "100%",
        }}
      >
        <Container className="signup-container">
          <Row className="justify-content-center">
            <Col xs={12} sm={10} md={8} lg={6} xl={5}>
              <div className="signup-box">
                <h2 className="text-center mb-4">Signup</h2>

                {message && <Alert variant="success">{message}</Alert>}
                {error && <Alert variant="danger">{error}</Alert>}

                <Form onSubmit={handleSubmit} className="signup-form">
                  <Form.Group controlId="email" className="mb-3">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                      type="email"
                      placeholder="Enter email"
                      value={email}
                      onChange={(e) => setEmail(e.target.value)}
                      required
                    />
                  </Form.Group>

                  <Row>
                    <Col xs={12} md={6}>
                      <Form.Group controlId="username" className="mb-3">
                        <Form.Label>First Name</Form.Label>
                        <Form.Control
                          type="text"
                          placeholder="Enter first name"
                          value={username}
                          onChange={(e) => setUsername(e.target.value)}
                          required
                        />
                      </Form.Group>
                    </Col>
                    <Col xs={12} md={6}>
                      <Form.Group controlId="lastName" className="mb-3">
                        <Form.Label>Last Name</Form.Label>
                        <Form.Control
                          type="text"
                          placeholder="Enter last name"
                          value={lastName}
                          onChange={(e) => setLastName(e.target.value)}
                          required
                        />
                      </Form.Group>
                    </Col>
                  </Row>

                  <Form.Group controlId="password" className="mb-3">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                      type="password"
                      placeholder="Enter password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      required
                    />
                  </Form.Group>

                  <Form.Group controlId="rePassword" className="mb-3">
                    <Form.Label>Re-enter Password</Form.Label>
                    <Form.Control
                      type="password"
                      placeholder="Re-enter password"
                      value={rePassword}
                      onChange={(e) => setRePassword(e.target.value)}
                      required
                    />
                  </Form.Group>

                  <Button type="submit" className="signup-btn w-100 mt-3">
                    Continue
                  </Button>
                </Form>
              </div>
            </Col>
          </Row>
        </Container>
      </div>
    </>
  );
}

export default Signup;