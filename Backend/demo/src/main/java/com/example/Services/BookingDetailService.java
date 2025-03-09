package com.example.Services;

import java.util.List;

import com.example.Models.BookingDetail;

public interface BookingDetailService {
	List<BookingDetail> getBookingDetail();
	BookingDetail addBookingDetail(BookingDetail Book);
	void deletebooking(int booking_id);
	List<BookingDetail> getBookingDetailByBookingId(int booking_id);
}
