package com.example.Controllers;

import java.awt.PageAttributes.MediaType;
import java.net.http.HttpHeaders;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
//import org.springframework.util.LinkedMultiValueMap;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import com.example.Models.BookingHeader;
import com.example.Models.CarMaster;
import com.example.Repositories.CarMasterRepository;
import com.example.Services.BookingHeaderService;
import com.example.dto.BookingHeaderDTO;

@RestController
@RequestMapping("/api")
@CrossOrigin(origins = "http://localhost:3000")
public class BookingHeaderController {

    @Autowired
    private BookingHeaderService booking_header_service;
    
    @Autowired 
    private CarMasterRepository carMasterRepository; 
    
    @Autowired
    private RestTemplate restTemplate;
    
    @GetMapping("/bookings")
    public ResponseEntity<List<BookingHeaderDTO>> getAllBookings() {
        List<BookingHeaderDTO> bookings = booking_header_service.getAllBookings();
        return ResponseEntity.ok(bookings);
    }

   
    @PostMapping("/addbooking")
    public ResponseEntity<BookingHeader> save(@RequestBody BookingHeader booking) {

        if (booking.getCar() == null || booking.getCar().getCarId() == null) {
            throw new RuntimeException("Car is required for the booking.");
        }

        Long carId = booking.getCar().getCarId();
        CarMaster car = carMasterRepository.findById(carId)
                .orElseThrow(() -> new RuntimeException("Car not found with id: " + carId));

        // Set CarMaster in booking
        booking.setCar(car);

        // Save booking in the database
        BookingHeader savedBooking = booking_header_service.save(booking);

     
        // Prepare email request data
        Map<String, String> emailRequest = new HashMap<>();
        emailRequest.put("email", booking.getEmailId());  // Ensure booking has email
        emailRequest.put("message", "Dear " + booking.getFirstname() + " " + booking.getLastname() + "," +
                "<br><br>Your booking has been successfully confirmed." +
                "<br><strong>Booking ID:</strong> " + savedBooking.getBookingId() +
                "<br><strong>Pickup Location:</strong> " + savedBooking.getPickup_hubAddress() +
                "<br><strong>Return Location:</strong> " + savedBooking.getReturn_hubAddress() +
                "<br><strong>Car:</strong> " + savedBooking.getCar().getCarName() +
                "<br><strong>Start Date:</strong> " + savedBooking.getStartdate() +
                "<br><strong>End Date:</strong> " + savedBooking.getEnddate() +
                "<br><br>Thank you for choosing Hire&Go!");

        // Send email using RestTemplate
        try {
            restTemplate.postForObject("http://localhost:8081/email", emailRequest, String.class);
        } catch (Exception e) {
            System.err.println("An error occurred while sending the email: " + e.getMessage());
        }

        // Return the saved booking
        return ResponseEntity.ok(savedBooking);
    }

    @GetMapping("/booking/email/{emailId}")
    public ResponseEntity<List<BookingHeaderDTO>> getBookingByEmailId(@PathVariable String emailId) {
        List<BookingHeaderDTO> bookings = booking_header_service.getBookingDetailsByEmailId(emailId);
        return ResponseEntity.ok(bookings);
    }

    
    @DeleteMapping("/deletebooking/{bookingId}")
    public ResponseEntity<String> deleteBooking(@PathVariable Long bookingId) {
        booking_header_service.deleteBooking(bookingId);
        return ResponseEntity.ok("Booking deleted successfully.");
    }
}


