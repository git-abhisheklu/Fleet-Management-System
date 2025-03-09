import React, { useState } from "react";
import { Form, Button, Container, Alert, Row, Col } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import Navbar from '../Components/Navbar';
import Footer2 from '../Components/Footer2';
import login from '../assets/login.png'; // Import the background image
import "./LoginForm.css";

function LoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    setError(""); // Reset error state
    const userData = { email, password };

    try {
      const response = await fetch("http://localhost:8080/auth/signIn", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(userData),
      });

      if (!response.ok) {
        throw new Error("Invalid email or password.");
      }

      const token = await response.text(); // API returns token as a plain string

      if (token) {
        sessionStorage.setItem("jwtToken", token);
        sessionStorage.setItem("email", email);
        sessionStorage.setItem("isAuthenticated", "true"); // Set authentication flag
        alert("Login successful!");
        navigate("/"); // Redirect to home page
        window.location.reload(); // Refresh page to update navbar
      } else {
        throw new Error("Token not received.");
      }
    } catch (error) {
      setError(error.message);
    }
  };

  return (
    <>
      <Navbar />
      <div
        style={{
          backgroundImage: `url(${login})`,
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
        <Container className="login-container">
          <Row className="justify-content-center">
            <Col xs={12} sm={10} md={8} lg={6} xl={5}>
              <div className="login-box">
                <h2 className="text-center">Login</h2>
                <Form onSubmit={handleLogin} className="login-form">
                  {error && <Alert variant="danger">{error}</Alert>}

                  <Form.Group className="mb-3">
                    <Form.Label>Email</Form.Label>
                    <Form.Control
                      type="email"
                      placeholder="Enter email"
                      value={email}
                      onChange={(e) => setEmail(e.target.value)}
                      required
                    />
                  </Form.Group>

                  <Form.Group className="mb-3">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                      type="password"
                      placeholder="Enter password"
                      value={password}
                      onChange={(e) => setPassword(e.target.value)}
                      required
                    />
                  </Form.Group>

                  <Button type="submit" className="login-btn w-100">
                    Login
                  </Button>

                  <p className="text-center mt-3">
                    Don't have an account? <Link to="/signup">Register here</Link>
                  </p>
                </Form>
              </div>
            </Col>
          </Row>
        </Container>
      </div>
      <Footer2 />
    </>
  );
}

export default LoginForm;