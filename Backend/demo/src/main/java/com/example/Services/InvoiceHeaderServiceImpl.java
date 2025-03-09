//package com.example.Services;
//
//import com.example.Models.InvoiceHeader;
//import com.example.Repositories.BookingHeaderRepository;
//import com.example.Repositories.CarMasterRepository;
//import com.example.Repositories.CustomerRepository;
//import com.example.Repositories.HubRepository;
//import com.example.Repositories.InvoiceHeaderRepository;
//import com.example.Models.BookingHeader;
//import com.example.Models.CarMaster;
//import com.example.Models.CustomerMaster;
//import com.example.Models.HubMaster;
//
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.stereotype.Service;
//
//import java.time.LocalDate;
//import java.util.List;
//
//@Service
//public class InvoiceHeaderServiceImpl implements InvoiceHeaderService {
//
//    @Autowired
//    private InvoiceHeaderRepository invoiceHeaderRepository;
//    
//    @Autowired
//    private BookingHeaderRepository bookingHeaderRepository;
//
//    @Autowired
//    private CarMasterRepository carMasterRepository;
//
//    @Autowired
//    private CustomerRepository customerMasterRepository;
//
//    @Autowired
//    private HubRepository hubMasterRepository;
//
//    @Override
//    public InvoiceHeader createInvoiceHeader(Long bookingId, Long carId, Long customerId, Long pickupHubId, Long returnHubId, String rate) {
//        // Retrieve data based on IDs provided
//        BookingHeader bookingHeader = bookingHeaderRepository.findById(bookingId).orElseThrow(() -> new RuntimeException("Booking not found"));
//        CarMaster carMaster = carMasterRepository.findById(carId).orElseThrow(() -> new RuntimeException("Car not found"));
//        CustomerMaster customerMaster = customerMasterRepository.findById(customerId).orElseThrow(() -> new RuntimeException("Customer not found"));
//        HubMaster pickupHub = hubMasterRepository.findById(pickupHubId).orElseThrow(() -> new RuntimeException("Pickup Hub not found"));
//        HubMaster returnHub = hubMasterRepository.findById(returnHubId).orElseThrow(() -> new RuntimeException("Return Hub not found"));
//
//        // Create new InvoiceHeader
//        InvoiceHeader invoiceHeader = new InvoiceHeader();
//        invoiceHeader.setBooking(bookingHeader);
//        invoiceHeader.setCar(carMaster);
//        invoiceHeader.setCustomer(customerMaster);
//        invoiceHeader.setPickup_hubId(pickupHubId);
//        invoiceHeader.setReturn_hubId(returnHubId);
//        invoiceHeader.setRate(rate);
//        invoiceHeader.setHandoverDate(LocalDate.now()); 
//        invoiceHeader.setReturnDate(LocalDate.now().plusDays(7)); 
//        invoiceHeader.setRentalAmt(carMaster.getRentalPrice()); 
//        invoiceHeader.setTotalAddOnAmt(0); 
//        invoiceHeader.setTotalAmt(invoiceHeader.getRentalAmt()); 
//
//        // Save the invoice header to DB
//        return invoiceHeaderRepository.save(invoiceHeader);
//    }
//
//    @Override
//    public InvoiceHeader getInvoiceHeaderById(Long invoiceId) {
//        return invoiceHeaderRepository.findById(invoiceId).orElseThrow(() -> new RuntimeException("Invoice not found"));
//    }
//
//    @Override
//    public List<InvoiceHeader> getAllInvoiceHeaders() {
//        return invoiceHeaderRepository.findAll();
//    }
//}
