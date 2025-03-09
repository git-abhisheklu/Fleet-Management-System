import React, { useState, useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { Container, Card, Button, Alert, Spinner, Form } from "react-bootstrap";
import Navbar from "../Components/Navbar";
import Footer2 from "../Components/Footer2";
import hub from "../assets/hub.png";
import "./HubSelection.css";

function HubSelection() {
  const [hubs, setHubs] = useState([]);
  const [selectedHub, setSelectedHub] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  
  const navigate = useNavigate();
  const location = useLocation();
  
  // Get City ID or Airport Code from previous page
  const { cityId, airportCode } = location.state || {};

  useEffect(() => {
    if (!cityId && !airportCode) {
      setError("No City ID or Airport Code provided.");
      setLoading(false);
      return;
    }

    const fetchHubs = async () => {
      setLoading(true);
      setError(null);

      const url = cityId
        ? `http://localhost:8080/api/hubs/city/${cityId}`
        : `http://localhost:8080/api/hubs/airportCode/${airportCode}`;

      try {
        const response = await fetch(url);
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setHubs(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchHubs();
  }, [cityId, airportCode]);

  const handleSelect = (hub) => {
    setSelectedHub(hub);
  };

  const handleContinue = () => {
    if (!selectedHub) {
      alert("Please select a hub.");
      return;
    }
    navigate("/VehicleSelection", { state: { selectedHub } });
  };

  return (
    <>
    <div style={{ display: 'flex',
      flexDirection: 'column',
      minHeight: '100vh',
      backgroundImage: `url(${hub})`, // Update the path to your image
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
    }}
    >
      <Navbar />
      <Container className="hub-selection">
        <h2 className="text-center">Select a Hub</h2>

        {loading && <Spinner animation="border" className="d-block mx-auto" />}
        {error && <Alert variant="danger">{error}</Alert>}

        {!loading && hubs.length === 0 && <Alert variant="warning">No hubs available.</Alert>}

        <Form>
          {hubs.map((hub) => (
            <Card key={hub.hubId} className="hub-card" onClick={() => handleSelect(hub)}>
              <Card.Body>
                <Form.Check
                  type="radio"
                  name="hub"
                  id={`hub-${hub.hubId}`}
                  label={`${hub.hubName} - ${hub.hubAddress} (${hub.contactNumber})`}
                  checked={selectedHub?.hubId === hub.hubId}
                  onChange={() => handleSelect(hub)}
                />
              </Card.Body>
            </Card>
          ))}
        </Form>

        <div className="button-group">
          <Button variant="primary" onClick={handleContinue} disabled={!selectedHub}>
            Continue
          </Button>
          <Button variant="secondary" onClick={() => navigate("/")}>
            Cancel
          </Button>
        </div>
      </Container>
      <Footer2 />
      </div>
    </>
  );
}

export default HubSelection;



// import React, { useState, useEffect } from 'react';


// const HubSelection = () => {
//   const [hubs, setHubs] = useState([]);
//   const [loading, setLoading] = useState(true);
//   const [error, setError] = useState(null);

//   useEffect(() => {
//     const pickupCity = localStorage.getItem('pickupCity') || '';
//     const pickupLocation = localStorage.getItem('pickupLocation') || '';

//     const searchParam = pickupCity || pickupLocation;
//     if (!searchParam) {
//       setError('No location provided.');
//       setLoading(false);
//       return;
//     }

//     const fetchHubs = async () => {
//       try {
//         const response = await fetch(`http://localhost:8080/api/hubs?location=${searchParam}`);
//         if (!response.ok) throw new Error('Failed to fetch hubs');
//         const data = await response.json();
//         setHubs(data);
//       } catch (err) {
//         setError(err.message);
//       } finally {
//         setLoading(false);
//       }
//     };

//     fetchHubs();
//   }, []);

//   return (
//     <div>
//       <h2>Available Hubs</h2>
//       {loading && <p>Loading hubs...</p>}
//       {error && <p style={{ color: 'red' }}>{error}</p>}
//       {!loading && !error && hubs.length > 0 ? (
//         <ul>
//           {hubs.map((hub, index) => (
//             <li key={index}>{hub.name} - {hub.address}</li>
//           ))}
//         </ul>
//       ) : (
//         !loading && <p>No hubs available for this location.</p>
//       )}
//     </div>
//   );
// };

// export default HubSelection;





