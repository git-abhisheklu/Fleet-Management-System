import React from "react";
import { Container, Grid, TextField, Button, Typography, Box } from "@mui/material";
import './Footer2.css';

const Footer2 = () => {
  const year = new Date().getFullYear();

  return (
    <Box
      component="footer"
      className="footer"
    >
      <Container>
        <Grid container spacing={4} justifyContent="center">
          {/* About Section */}
          <Grid item xs={12} sm={6} md={4}>
            <Typography variant="h5" gutterBottom>
              About Us
            </Typography>
            <Typography variant="body2">
              Lorem ipsum dolor sit amet consectetur adipisicing elit.
              Consequuntur, distinctio, itaque reiciendis ab cupiditate harum ex
              quam veniam, omnis expedita animi quibusdam obcaecati mollitia?
              Delectus et ad illo recusandae temporibus?
            </Typography>
          </Grid>

          {/* Quick Links */}
          <Grid item xs={12} sm={6} md={2}>
            <Typography variant="h5" gutterBottom>
              Quick Links
            </Typography>
            <Typography variant="body2">
              <a href="/">Home</a>
            </Typography>
            <Typography variant="body2">
              <a href="/AboutUs">About Us</a>
            </Typography>
            <Typography variant="body2">
              <a href="/services">Services</a>
            </Typography>
            <Typography variant="body2">
              <a href="/contact">Contact</a>
            </Typography>
          </Grid>

          {/* Contact Information */}
          <Grid item xs={12} sm={6} md={3}>
            <Typography variant="h5" gutterBottom>
              Head Office
            </Typography>
            <Typography variant="body2">47, Hauz Khas, New Delhi</Typography>
            <Typography variant="body2">Phone: +91 9267692676</Typography>
            <Typography variant="body2">Email: hire&go@gmail.com</Typography>
            <Typography variant="body2">Office Time: 10:00 AM - 01:00 PM</Typography>
          </Grid>

          {/* Newsletter */}
          <Grid item xs={12} sm={6} md={3}>
            <Typography variant="h5" gutterBottom>
              Newsletter
            </Typography>
            <Typography variant="body2">Subscribe to our newsletter</Typography>
            <Box display="flex" mt={2}>
              <TextField
                variant="outlined"
                size="small"
                placeholder="Enter your email"
                className="MuiTextField-root"
              />
              <Button
                variant="contained"
                className="MuiButton-root"
              >
                Subscribe
              </Button>
            </Box>
          </Grid>
        </Grid>

        {/* Footer Bottom */}
        <Box mt={4} pt={2} borderTop="1px solid #555" className="footer-bottom">
          <Typography variant="body2">
            &copy; {year} Developed by Lemon Chushi. All rights reserved.
          </Typography>
        </Box>
      </Container>
    </Box>
  );
};

export default Footer2;