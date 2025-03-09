package com.example.Models;

import java.time.LocalDate;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonBackReference;

import jakarta.persistence.*;

@Entity
public class InvoiceHeader {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long invoiceId;

    @ManyToOne
    @JoinColumn(name = "bookingId", nullable = false)
    @JsonBackReference 
    private BookingHeader booking;
    
    private String cName; 
    private String cEmailId; 
    private String cMobileNo; 
    private String cAadharNo; 
    private String cPassNo; 

    @ManyToOne
    @JoinColumn(name = "customerId", nullable = false)
    private CustomerMaster customer;
    
    @OneToMany(mappedBy = "invoice", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<InvoiceDetails> invoiceDetails;
    
    private Long pickup_hubId;
    private Long return_hubId;

    @Enumerated(EnumType.STRING)
    @Column(name = "isReturned", length = 1)
    private Return_Status isReturned;
    
    public enum Return_Status {
        Y, N
    }

    private LocalDate handoverDate;

    @ManyToOne
    @JoinColumn(name = "carId", nullable = false)
    private CarMaster car;

    private LocalDate returnDate;
    private double rentalAmt;
    private double totalAddOnAmt;
    private double totalAmt;
    private String rate;

    // Getters and Setters
    public Long getInvoiceId() {
        return invoiceId;
    }

    public void setInvoiceId(Long invoiceId) {
        this.invoiceId = invoiceId;
    }

    public BookingHeader getBooking() {
        return booking;
    }

    public void setBooking(BookingHeader booking) {
        this.booking = booking;
    }

    public CustomerMaster getCustomer() {
        return customer;
    }

    public void setCustomer(CustomerMaster customer) {
        this.customer = customer;
    }

    public LocalDate getHandoverDate() {
        return handoverDate;
    }

    public void setHandoverDate(LocalDate handoverDate) {
        this.handoverDate = handoverDate;
    }

    public CarMaster getCar() {
        return car;
    }

    public void setCar(CarMaster car) {
        this.car = car;
    }

    public LocalDate getReturnDate() {
        return returnDate;
    }

    public void setReturnDate(LocalDate returnDate) {
        this.returnDate = returnDate;
    }

    public double getRentalAmt() {
        return rentalAmt;
    }

    public void setRentalAmt(double rentalAmt) {
        this.rentalAmt = rentalAmt;
    }

    public double getTotalAddOnAmt() {
        return totalAddOnAmt;
    }

    public void setTotalAddOnAmt(double totalAddOnAmt) {
        this.totalAddOnAmt = totalAddOnAmt;
    }

    public double getTotalAmt() {
        return totalAmt;
    }

    public void setTotalAmt(double totalAmt) {
        this.totalAmt = totalAmt;
    }

    public String getRate() {
        return rate;
    }

    public void setRate(String rate) {
        this.rate = rate;
    }

    public Return_Status getIsReturned() {
        return isReturned;
    }

    public void setIsReturned(Return_Status isReturned) {
        this.isReturned = isReturned;
    }

    public Long getPickup_hubId() {
        return pickup_hubId;
    }

    public void setPickup_hubId(Long pickup_hubId) {
        this.pickup_hubId = pickup_hubId;
    }

    public Long getReturn_hubId() {
        return return_hubId;
    }

    public void setReturn_hubId(Long return_hubId) {
        this.return_hubId = return_hubId;
    }

    @Override
    public String toString() {
        return "InvoiceHeader [invoiceId=" + invoiceId + ", booking=" + booking + ", cName=" + cName + 
                ", cEmailId=" + cEmailId + ", cMobileNo=" + cMobileNo + ", cAadharNo=" + cAadharNo + 
                ", cPassNo=" + cPassNo + ", customer=" + customer + ", pickup_hubId=" + pickup_hubId + 
                ", return_hubId=" + return_hubId + ", isReturned=" + isReturned + ", handoverDate=" + handoverDate + 
                ", car=" + car + ", returnDate=" + returnDate + ", rentalAmt=" + rentalAmt + 
                ", totalAddOnAmt=" + totalAddOnAmt + ", totalAmt=" + totalAmt + ", rate=" + rate + "]";
    }
}
