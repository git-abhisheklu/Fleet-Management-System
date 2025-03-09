package com.example.Models;
import java.time.LocalDate;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;

@Entity
public class Membership {
	
	 @Id
	 @GeneratedValue(strategy = GenerationType.IDENTITY)
	 private Long membershipId;
	
	 private String membershipType;
	 
	 private Double fee;
	 
	 private LocalDate startDate;
	 
	 private LocalDate endDate;
	 

	 @ManyToOne
	 @JoinColumn(name = "customerId", nullable = false)
	 private CustomerMaster customer;
	    
	 public Membership() {}

	    public Membership(Long membershipId, String membershipType, Double fee, LocalDate startDate, LocalDate endDate, CustomerMaster customer) {
	        this.membershipId = membershipId;
	        this.membershipType = membershipType;
	        this.fee = fee;
	        this.startDate = startDate;
	        this.endDate = endDate;
	        this.customer = customer;
	    }

	    public Long getMembershipId() {
	        return membershipId;
	    }

	    public void setMembershipId(Long membershipId) {
	        this.membershipId = membershipId;
	    }

	    public String getMembershipType() {
	        return membershipType;
	    }

	    public void setMembershipType(String membershipType) {
	        this.membershipType = membershipType;
	    }

	    public Double getFee() {
	        return fee;
	    }

	    public void setFee(Double fee) {
	        this.fee = fee;
	    }

	    public LocalDate getStartDate() {
	        return startDate;
	    }

	    public void setStartDate(LocalDate startDate) {
	        this.startDate = startDate;
	    }

	    public LocalDate getEndDate() {
	        return endDate;
	    }

	    public void setEndDate(LocalDate endDate) {
	        this.endDate = endDate;
	    }

	    public CustomerMaster getCustomer() {
	        return customer;
	    }

	    public void setCustomer(CustomerMaster customer) {
	        this.customer = customer;
	    }
	 
	    @Override
	    public String toString() {
	        return "Membership{" +
	                "membershipId=" + membershipId +
	                ", membershipType='" + membershipType + '\'' +
	                ", fee=" + fee +
	                ", startDate=" + startDate +
	                ", endDate=" + endDate +
	                ", customer=" + customer +
	                '}';
	    }
}
