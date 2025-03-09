package com.example.dto;

public class BookingDetailDTO {
    private Long bookingDetailId;
    private Long addonId;
    private Double addonRate;

    public BookingDetailDTO(Long bookingDetailId, Long addonId, Double addonRate) {
        this.bookingDetailId = bookingDetailId;
        this.addonId = addonId;
        this.addonRate = addonRate;
    }

	public Long getBookingDetailId() {
		return bookingDetailId;
	}

	public void setBookingDetailId(Long bookingDetailId) {
		this.bookingDetailId = bookingDetailId;
	}

	public Long getAddonId() {
		return addonId;
	}

	public void setAddonId(Long addonId) {
		this.addonId = addonId;
	}

	public Double getAddonRate() {
		return addonRate;
	}

	public void setAddonRate(Double addonRate) {
		this.addonRate = addonRate;
	}


}