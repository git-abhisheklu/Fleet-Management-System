package com.example.Services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.BookingDetail;
import com.example.Repositories.BookingDetailRepository;

@Service
public class BookingDetailServiceImpl implements BookingDetailService{
	
	@Autowired
	private BookingDetailRepository bookingdetailrepository;

	@Override
	public List<BookingDetail> getBookingDetail() {
		return bookingdetailrepository.findAll();
	}

	@Override
	public BookingDetail addBookingDetail(BookingDetail Book) {
		return bookingdetailrepository.save(Book);
	}

	@Override
	public void deletebooking(int booking_id) {
		bookingdetailrepository.deleteByBookingId(booking_id);
		
	}

	@Override
	public List<BookingDetail> getBookingDetailByBookingId(int booking_id) {
		return bookingdetailrepository.getBookingDetailByBookingId(booking_id);
	}

}
