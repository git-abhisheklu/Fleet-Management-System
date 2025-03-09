package com.example.Controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.Models.BookingDetail;
import com.example.Services.BookingDetailService;

@RestController
@RequestMapping("/api")
@CrossOrigin(origins = "http://localhost:3000")
public class BookingDetailController {

	@Autowired
	private BookingDetailService  bookingdetailservice;
	@GetMapping("/bookingdetails")
	public List<BookingDetail> getAllAddOns() {
		
		return bookingdetailservice.getBookingDetail();
		
	}
	
	@PostMapping("/addbookingdetails")
	public BookingDetail postAllAddOns(@RequestBody BookingDetail booking2) {
		
		return bookingdetailservice.addBookingDetail(booking2);
		
	}
	

	@DeleteMapping("/bookingdetails/{deletebooking}")
	public void delete(@PathVariable int deletebooking) {
		
		bookingdetailservice.deletebooking(deletebooking);
		
	}
	
	@GetMapping("/bookingdetails/booking_id/{booking_id}")
	public List<BookingDetail> getBookingDetailByBookingId(@PathVariable int booking_id) {
		return bookingdetailservice.getBookingDetailByBookingId(booking_id);
	}
}
