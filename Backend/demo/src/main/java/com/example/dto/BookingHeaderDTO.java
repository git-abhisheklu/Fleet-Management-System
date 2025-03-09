package com.example.dto;

import java.time.LocalDate;
import java.util.List;

import com.example.Models.BookingHeader;

import jakarta.persistence.Column;

public class BookingHeaderDTO {
    private Long bookingId;
    private LocalDate bookingdate;
    private String firstname;
    private String lastname;
  
    private LocalDate startdate;  

    private LocalDate enddate;  
    
	public void setStartdate(LocalDate startdate) {
		this.startdate = startdate;
	}

	public LocalDate getEnddate() {
		return enddate;
	}
    public LocalDate getStartdate() {
		return startdate;
	}

	public Long getBookingId() {
		return bookingId;
	}

	public void setBookingId(Long bookingId) {
		this.bookingId = bookingId;
	}

	public LocalDate getBookingdate() {
		return bookingdate;
	}

	public void setBookingdate(LocalDate bookingdate) {
		this.bookingdate = bookingdate;
	}

	public String getFirstname() {
		return firstname;
	}

	public void setFirstname(String firstname) {
		this.firstname = firstname;
	}

	public String getLastname() {
		return lastname;
	}

	public void setLastname(String lastname) {
		this.lastname = lastname;
	}

	public String getEmailId() {
		return emailId;
	}

	public void setEmailId(String emailId) {
		this.emailId = emailId;
	}

	public Double getDailyrate() {
		return dailyrate;
	}

	public void setDailyrate(Double dailyrate) {
		this.dailyrate = dailyrate;
	}

	public Double getWeeklyrate() {
		return weeklyrate;
	}

	public void setWeeklyrate(Double weeklyrate) {
		this.weeklyrate = weeklyrate;
	}

	public Double getMonthlyrate() {
		return monthlyrate;
	}

	public void setMonthlyrate(Double monthlyrate) {
		this.monthlyrate = monthlyrate;
	}

	public String getPickup_hubAddress() {
		return pickup_hubAddress;
	}

	public void setPickup_hubAddress(String pickup_hubAddress) {
		this.pickup_hubAddress = pickup_hubAddress;
	}

	public String getReturn_hubAddress() {
		return return_hubAddress;
	}

	public void setReturn_hubAddress(String return_hubAddress) {
		this.return_hubAddress = return_hubAddress;
	}

	public List<BookingDetailDTO> getBookingDetails() {
		return bookingDetails;
	}

	public void setBookingDetails(List<BookingDetailDTO> bookingDetails) {
		this.bookingDetails = bookingDetails;
	}

	private String emailId;
    private Double dailyrate;
    private Double weeklyrate;
    private Double monthlyrate;
    private String pickup_hubAddress;
    private String return_hubAddress;
    private List<BookingDetailDTO> bookingDetails;

    public BookingHeaderDTO(Long bookingId, LocalDate bookingdate, String firstname, String lastname, 
                            String emailId, Double dailyrate, Double weeklyrate, Double monthlyrate,LocalDate startdate,LocalDate enddate,
                            String pickup_hubAddress, String return_hubAddress, List<BookingDetailDTO> bookingDetails) {
        this.bookingId = bookingId;
        this.bookingdate = bookingdate;
        this.firstname = firstname;
        this.lastname = lastname;
        this.emailId = emailId;
        this.dailyrate = dailyrate;
        this.weeklyrate = weeklyrate;
        this.monthlyrate = monthlyrate;
        this.pickup_hubAddress = pickup_hubAddress;
        this.return_hubAddress = return_hubAddress;
        this.bookingDetails = bookingDetails;
        this.startdate =startdate;
        this.enddate=enddate;
    }
   

    // Getters and setters
}