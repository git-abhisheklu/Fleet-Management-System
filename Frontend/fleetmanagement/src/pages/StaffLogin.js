import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Navbar from '../Components/Navbar';
import Footer2 from '../Components/Footer2';
import staff from '../assets/staff.png'; // Import the background image
import './StaffLogin.css'; // Import the CSS file

const StaffLogin = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const navigate = useNavigate();

  const handleLogin = () => {
    const validUsername = 'admin';
    const validPassword = 'admin';

    if (username === validUsername && password === validPassword) {
      sessionStorage.setItem('isAuthenticated', 'true'); // Set authentication flag
      sessionStorage.setItem('isStaff', 'true'); // Set staff flag
      navigate('/'); // Redirect to home page
      window.location.reload(); // Refresh page to update navbar
    } else {
      setError('Invalid username or password');
    }
  };

  return (
    <>
      <Navbar />
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
        <div className="staff-login-container">
          {/* Staff Login Box */}
          <div className="container">
            <div className="row justify-content-center mt-0 mb-5">
              <div className="col-md-6">
                <div className="card">
                  <div className="card-body">
                    <h2 className="card-title mb-4">Staff Login</h2>
                    <div className="mb-3">
                      <label htmlFor="username" className="form-label">
                        Username
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        id="username"
                        placeholder="Enter your username"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                      />
                    </div>
                    <div className="mb-3">
                      <label htmlFor="password" className="form-label">
                        Password
                      </label>
                      <input
                        type="password"
                        className="form-control"
                        id="password"
                        placeholder="Enter your password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                      />
                    </div>
                    <div className="mb-3">
                      <label htmlFor="role" className="form-label">
                        Role
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        id="role"
                        placeholder="Admin"
                        value="Admin"
                        readOnly
                        disabled
                      />
                    </div>
                    {error && <div className="text-danger mb-3">{error}</div>}
                    <button
                      type="button"
                      className="btn btn-primary"
                      onClick={handleLogin}
                    >
                      Login
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <Footer2 />
    </>
  );
};

export default StaffLogin;