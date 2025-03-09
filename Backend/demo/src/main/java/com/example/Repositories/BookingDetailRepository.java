package com.example.Repositories;
import com.example.Models.BookingDetail;

import jakarta.transaction.Transactional;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;


public interface BookingDetailRepository extends JpaRepository<BookingDetail,Long>{
	@Modifying
    @Transactional
	@Query(value = "Delete FROM booking_detail WHERE booking_id = :booking_id", nativeQuery = true)
	void deleteByBookingId(@Param("booking_id") int booking_id);
	
	@Query(value = "select * from booking_detail WHERE booking_id = :booking_id",nativeQuery = true)
	List<BookingDetail> getBookingDetailByBookingId(@Param("booking_id") int booking_id);
}
