import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import '../Components/Navbar.css';

const Navbar = () => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [isStaff, setIsStaff] = useState(false); // State to check if the user is staff
    const navigate = useNavigate();

    // Check authentication status on component mount
    useEffect(() => {
        const authStatus = sessionStorage.getItem('isAuthenticated');
        const staffStatus = sessionStorage.getItem('isStaff'); // Check if the user is staff
        if (authStatus === 'true') {
            setIsAuthenticated(true);
        }
        if (staffStatus === 'true') {
            setIsStaff(true); // Set isStaff to true if the user is staff
        }
    }, []);

    // Handle logout
    const handleLogout = () => {
        sessionStorage.removeItem('isAuthenticated'); // Clear authentication flag
        sessionStorage.removeItem('isStaff'); // Clear staff flag
        setIsAuthenticated(false); // Update state
        setIsStaff(false); // Update staff state
        navigate('/'); // Redirect to home page
    };

    // Handle staff-specific actions
    const handleStaffAction = (path) => {
        navigate(path);
    };

    return (
        <header className="header-navbar">
            <nav className="navbar">
                <div className="navbar-brand">
                    <Link to="/" style={{ textDecoration: 'none' }}>
                        <h2 style={{ color: "white", fontWeight: 'bold' }}>Hire & Go</h2>
                    </Link>
                </div>

                <div className="navbar-left">
                    <Link to="/">Home</Link>
                    <Link to="/ModifyCancel">Modify/Cancel Booking</Link>
                    <Link to="/Signup">Membership Registration</Link>
                    <Link to="/AboutUs">About us</Link>
                    <Link to="/CustomerCare">Customer Care</Link>
                </div>

                <div className="navbar-right">
                    {isAuthenticated ? (
                        <>
                            {isStaff && (
                                <div className="staff-options">
                                    <button onClick={() => handleStaffAction("/ReservationByStaff")}>Booking</button>
                                    <button onClick={() => handleStaffAction("/HandOverDetails")}>Handover</button>
                                    <button onClick={() => handleStaffAction("/Return")}>Return</button>
                                    <button onClick={() => handleStaffAction("/CancleBookingByStaff")}>Cancellation</button>
                                </div>
                            )}
                            <button onClick={handleLogout} className="logout-button">
                                Logout
                            </button>
                        </>
                    ) : (
                        <>
                            <Link to="/LoginForm">Login</Link>
                            <Link to="/StaffLogin">Staff Login</Link>
                        </>
                    )}
                </div>
            </nav>
        </header>
    );
};

export default Navbar;