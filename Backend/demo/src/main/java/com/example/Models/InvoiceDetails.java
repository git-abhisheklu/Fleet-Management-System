package com.example.Models;


import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;

@Entity
public class InvoiceDetails {
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long invdtlId;

    @ManyToOne
    @JoinColumn(name = "invoiceId" , nullable = false,referencedColumnName = "invoiceId")
    private InvoiceHeader invoice;

    @ManyToOne
    @JoinColumn(name = "addonId" , nullable = false,referencedColumnName = "addonId")
    private AddOnMaster addOn;

    private double addOnAmt;

	public Long getInvdtlId() {
		return invdtlId;
	}

	public void setInvdtlId(Long invdtlId) {
		this.invdtlId = invdtlId;
	}

	public InvoiceHeader getInvoice() {
		return invoice;
	}

	public void setInvoice(InvoiceHeader invoice) {
		this.invoice = invoice;
	}

	public AddOnMaster getAddOn() {
		return addOn;
	}

	public void setAddOn(AddOnMaster addOn) {
		this.addOn = addOn;
	}

	public double getAddOnAmt() {
		return addOnAmt;
	}

	public void setAddOnAmt(double addOnAmt) {
		this.addOnAmt = addOnAmt;
	}

	@Override
	public String toString() {
		return "InvoiceDetail [invdtlId=" + invdtlId + ", invoice=" + invoice + ", addOnAmt=" + addOnAmt + "]";
	}

	public InvoiceDetails(Long invdtlId, InvoiceHeader invoice, AddOnMaster addOn, double addOnAmt) {
		super();
		this.invdtlId = invdtlId;
		this.invoice = invoice;
		this.addOn = addOn;
		this.addOnAmt = addOnAmt;
	}

	public InvoiceDetails() {
		
	}
}