package com.example.Models;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonManagedReference;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Entity
@Table(name = "booking")
@Data
@NoArgsConstructor
@AllArgsConstructor
public class BookingHeader {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long bookingId;  

    @Column(nullable = false)
    private LocalDate bookingdate;  
    
   
    @ManyToOne
    @JoinColumn(name = "customerId")
 
    private CustomerMaster customer;  

    @Column(nullable = false)
    private LocalDate startdate;  

    @Column(nullable = false)
    private LocalDate enddate;  
    
    @ManyToOne
    @JoinColumn(name = "carId", nullable = false)  
   
    private CarMaster car;  

    @ManyToOne
    @JoinColumn(name = "cartypeId",referencedColumnName = "cartypeId", nullable = false)  
   
    private CarTypeMaster cartype;  
    
  

    @OneToMany(mappedBy = "booking", cascade = CascadeType.ALL)
    @JsonManagedReference
    private List<BookingDetail> bookingDetails = new ArrayList<BookingDetail>();


    
    @Column(nullable = false)
    private String firstname;  // Customer name
    
    @Column(nullable = false)
    private String lastname;

    @Column(nullable = false)
    private String address;  // Customer address

    @Column(nullable = false)
    private String state;  // Customer state

    @Column(nullable = false)
    private String pin; 
    
    @Column(nullable=false)
    private String emailId;
    
//    @OneToOne(cascade = CascadeType.ALL)
//    @JoinColumn(name = "invoice_id")
//    private InvoiceHeader invoiceHeader;
//    public InvoiceHeader getInvoiceHeader() {
//		return invoiceHeader;
//	}
//
//	public void setInvoiceHeader(InvoiceHeader invoiceHeader) {
//		this.invoiceHeader = invoiceHeader;
//	}

	private Double dailyrate;  // Reference to daily rate

    private Double weeklyrate;  // Reference to weekly rate

    private Double monthlyrate;  // Reference to monthly rate
    
    private String pickup_hubAddress;
	
    private String return_hubAddress;

	public Long getBookingId() {
		return bookingId;
	}

	public void setBookingId(Long bookingId) {
		this.bookingId = bookingId;
	}

	public LocalDate getDate() {
		return bookingdate;
	}

	public void setDate(LocalDate bookingdate) {
		this.bookingdate = bookingdate;
	}

//	public Long getCustid() {
//		return custid;
//	}

//	public void setCustid(Long customerId) {
//		this.customerId = customerId;
//	}

	public LocalDate getStartdate() {
		return startdate;
	}

	public CustomerMaster getCustomer() {
		return customer;
	}

	public void setCustomer(CustomerMaster customer) {
		this.customer = customer;
	}

	public CarMaster getCar() {
		return car;
	}

	public void setCar(CarMaster car) {
		this.car = car;
	}

	public CarTypeMaster getCartype() {
		return cartype;
	}

	public void setCartype(CarTypeMaster cartype) {
		this.cartype = cartype;
	}

	public List<BookingDetail> getBookingDetails() {
		return bookingDetails;
	}

	public void setBookingDetails(List<BookingDetail> bookingDetails) {
		this.bookingDetails = bookingDetails;
	}

	public void setStartdate(LocalDate startdate) {
		this.startdate = startdate;
	}

	public LocalDate getEnddate() {
		return enddate;
	}

	public void setEnddate(LocalDate enddate) {
		this.enddate = enddate;
	}

	public CarTypeMaster getCartypeid() {
		return cartype;
	}

	public void setCartypeid(CarTypeMaster cartype) {
		this.cartype = cartype;
	}

	

	public LocalDate getBookingdate() {
		return bookingdate;
	}

	public void setBookingdate(LocalDate bookingdate) {
		this.bookingdate = bookingdate;
	}

	public CustomerMaster getCustomerId() {
		return customer;
	}

	public void setCustomerId(CustomerMaster customer) {
		this.customer = customer;
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

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getState() {
		return state;
	}

	public void setState(String state) {
		this.state = state;
	}

	public String getPin() {
		return pin;
	}

	public void setPin(String pin) {
		this.pin = pin;
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

	
    
    public BookingHeader(Long bookingId, LocalDate bookingdate, CustomerMaster customer, LocalDate startdate,
			LocalDate enddate, CarMaster car, CarTypeMaster cartype, List<BookingDetail> bookingDetails,
			String firstname, String lastname, String address, String state, String pin, String emailId,
			Double dailyrate, Double weeklyrate, Double monthlyrate, String pickup_hubAddress, String return_hubAddress) {
		super();
		this.bookingId = bookingId;
		this.bookingdate = bookingdate;
		this.customer = customer;
		this.startdate = startdate;
		this.enddate = enddate;
		this.car = car;
		this.cartype = cartype;
		this.bookingDetails = bookingDetails;
		this.firstname = firstname;
		this.lastname = lastname;
		this.address = address;
		this.state = state;
		this.pin = pin;
		this.emailId = emailId;
		this.dailyrate = dailyrate;
		this.weeklyrate = weeklyrate;
		this.monthlyrate = monthlyrate;
		this.pickup_hubAddress = pickup_hubAddress;
		this.return_hubAddress = return_hubAddress;
	}

	public BookingHeader() {
    	
    }

	@Override
	public String toString() {
		return "BookingHeader [bookingId=" + bookingId + ", bookingdate=" + bookingdate + ", customer=" + customer
				+ ", startdate=" + startdate + ", enddate=" + enddate + ", car=" + car + ", cartype=" + cartype
				+ ", bookingDetails=" + bookingDetails + ", firstname=" + firstname + ", lastname=" + lastname
				+ ", address=" + address + ", state=" + state + ", pin=" + pin + ", emailId=" + emailId + ", dailyrate="
				+ dailyrate + ", weeklyrate=" + weeklyrate + ", monthlyrate=" + monthlyrate + ", pickup_hubAddress="
				+ pickup_hubAddress + ", return_hubAddress=" + return_hubAddress + "]";
	}

	

	
    
    
}