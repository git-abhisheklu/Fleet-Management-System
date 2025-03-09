package com.example.Repositories;


import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.example.Models.BookingHeader;

import jakarta.transaction.Transactional;

@Repository
@Transactional
public interface BookingHeaderRepository extends JpaRepository<BookingHeader,Long> {
	
	@Query(value="select * from booking where email_id =:email_id",nativeQuery =true	)
    public List<BookingHeader> getBookingByEmailId(@Param("email_id") String emailId);
}
