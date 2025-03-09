package com.example.Services;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.Models.BookingHeader;
import com.example.Models.CarMaster;
import com.example.Models.CarTypeMaster;
import com.example.Models.CustomerMaster;
import com.example.Models.InvoiceHeader;
import com.example.Repositories.BookingHeaderRepository;
import com.example.Repositories.CarMasterRepository;
import com.example.Repositories.CarTypeMasterRepository;
import com.example.Repositories.CustomerRepository;
import com.example.Repositories.InvoiceHeaderRepository;
import com.example.dto.BookingDetailDTO;
import com.example.dto.BookingHeaderDTO;

import jakarta.transaction.Transactional;

@Service
@Transactional
public class BookingHeaderServiceImpl implements BookingHeaderService{
	
	@Autowired
	private BookingHeaderRepository booking_header_repository;
	
	@Autowired
    private CarMasterRepository carMasterRepository;

	@Autowired
	private CustomerRepository customerRepository;

	@Autowired
	private CarTypeMasterRepository carTypeRepository;
	
//	@Autowired
//	private InvoiceHeaderRepository invoiceHeaderRepository;
	@Override
	public List<BookingHeader> getBookingByEmailId(String emailId) {
		
	return booking_header_repository.getBookingByEmailId(emailId);
		
	}
	
	
	@Override
	public Optional<BookingHeader> getBookingById(Long bookingId) {
	    return Optional.ofNullable(booking_header_repository.findById(bookingId)
	            .orElseThrow(() -> new RuntimeException("Booking not found with ID: " + bookingId)));
	}


	@Override
	public void deleteBooking(Long bookingId) {
		
		booking_header_repository.deleteById(bookingId);
	}

	@Override
	public BookingHeader save(BookingHeader booking) {
	    if (booking.getCar() == null || booking.getCar().getCarId() == null) {
	        throw new RuntimeException("Car is required for the booking.");
	    }

	    Long carId = booking.getCar().getCarId();
	    CarMaster car = carMasterRepository.findById(carId)
	            .orElseThrow(() -> new RuntimeException("Car not found with id: " + carId));
	    booking.setCar(car);

	    if (booking.getCustomer() == null || booking.getCustomer().getCustomerId() == null) {
	        throw new RuntimeException("Customer is required for the booking.");
	    }

	    Long customerId = booking.getCustomer().getCustomerId();
	    CustomerMaster customer = customerRepository.getCustomerById(customerId)
	            .orElseThrow(() -> new RuntimeException("Customer not found with id: " + customerId));
	    booking.setCustomer(customer);

	    if (booking.getCartype() == null || booking.getCartype().getCartypeId() == null) {
	        throw new RuntimeException("CarType is required for the booking.");
	    }

	    Long carTypeId = booking.getCartype().getCartypeId();
	    CarTypeMaster carType = carTypeRepository.findById(carTypeId)
	            .orElseThrow(() -> new RuntimeException("CarType not found with id: " + carTypeId));
	    booking.setCartype(carType);

	    // 🔹 Handle InvoiceHeader to Avoid Large Data Issue
//	    if (booking.getInvoiceHeader() != null) {
//	        booking.setInvoiceHeader(
//	            booking.getInvoiceHeader().getInvoiceId() != null
//	                ? invoiceHeaderRepository.findById(booking.getInvoiceHeader().getInvoiceId())
//	                    .orElseThrow(() -> new RuntimeException("Invoice not found with id: " + booking.getInvoiceHeader().getInvoiceId()))
//	                : invoiceHeaderRepository.save(booking.getInvoiceHeader())
//	        );
//	    }
	    // 🔹 Save Booking
	    return booking_header_repository.save(booking);
	}


	
	public List<BookingHeaderDTO> getBookingDetailsByEmailId(String emailId) {
        List<BookingHeader> bookings = getBookingByEmailId(emailId);
        
        return bookings.stream()
            .map(booking -> new BookingHeaderDTO(
                    booking.getBookingId(),
                    booking.getBookingdate(),
                    booking.getFirstname(),
                    booking.getLastname(),
                    booking.getEmailId(),
                    booking.getDailyrate(),
                    booking.getWeeklyrate(),
                    booking.getMonthlyrate(),
                    booking.getEnddate(),
                    booking.getStartdate(),
                     booking.getPickup_hubAddress(),
                    booking.getReturn_hubAddress(),
                    booking.getBookingDetails().stream()
                        .map(detail -> new BookingDetailDTO(
                            detail.getBookingDetailId(),
                            detail.getAddonId(),
                            detail.getAddonRate()))
                        .collect(Collectors.toList())
                ))
            .collect(Collectors.toList());
    }
	
	@Override
	public List<BookingHeaderDTO> getAllBookings() {
	    List<BookingHeader> bookings = booking_header_repository.findAll();
	    
	    return bookings.stream()
	        .map(booking -> new BookingHeaderDTO(
	                booking.getBookingId(),
	                booking.getBookingdate(),
	                booking.getFirstname(),
	                booking.getLastname(),
	                booking.getEmailId(),
	                booking.getDailyrate(),
	                booking.getWeeklyrate(),
	                booking.getMonthlyrate(),
	                booking.getEnddate(),
	                booking.getStartdate(),
	                booking.getPickup_hubAddress(),
	                booking.getReturn_hubAddress(),
	                booking.getBookingDetails().stream()
	                    .map(detail -> new BookingDetailDTO(
	                        detail.getBookingDetailId(),
	                        detail.getAddonId(),
	                        detail.getAddonRate()))
	                    .collect(Collectors.toList())
	            ))
	        .collect(Collectors.toList());
	}


}
