import React from "react";
import { CssBaseline, Container } from "@mui/material";
import Navbar from "../Components/Navbar"; 
import Footer2 from "../Components/Footer2";
import ReservationForm from '../Components/ReservationForm';
// import car from '../assets/car.png';
// import carimg from '../assets/carimg.jpg';
// import car1 from '../assets/car1.png';
import main from '../assets/main.png';

export const Abhishek2 = () => {
  return (
    <div style={{ display: 'flex',
      flexDirection: 'column',
      minHeight: '100vh',
      backgroundImage: `url(${main})`, // Update the path to your image
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
    }}
    >
      <CssBaseline />
      <Navbar />
      <Container sx={{ flex: "1 0 auto", mt: 8, mb: 4 }}>
        <ReservationForm />
      </Container>
      <Footer2 style={{ flexShrink: 0 }} />
    </div>
  );
};