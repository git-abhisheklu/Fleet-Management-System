package com.example.Services;

import java.util.List;
import java.util.Optional;

import org.springframework.stereotype.Service;

import com.example.Models.BookingHeader;
import com.example.dto.BookingHeaderDTO;


public interface BookingHeaderService {
	public List<BookingHeader> getBookingByEmailId(String emailId);
	void deleteBooking (Long bookingId);
	public BookingHeader save(BookingHeader booking);
	 List<BookingHeaderDTO> getBookingDetailsByEmailId(String emailId);
	 Optional<BookingHeader> getBookingById(Long bookingId);
	 List<BookingHeaderDTO> getAllBookings();


}
