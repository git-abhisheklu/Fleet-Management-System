package com.example.Services;

import com.example.Models.BookingDetail;
import com.example.Models.BookingHeader;
import com.example.Models.AddOnMaster;
import com.lowagie.text.*;
import com.lowagie.text.pdf.PdfPCell;
import com.lowagie.text.pdf.PdfPTable;
import com.lowagie.text.pdf.PdfWriter;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.io.ByteArrayOutputStream;
import java.time.temporal.ChronoUnit;
import java.util.List;
import java.util.Optional;

@Service
public class InvoicePdfService {

    @Autowired
    private BookingHeaderService bookingHeaderService;

    @Autowired
    private BookingDetailService bookingDetailService;

    @Autowired
    private AddOnMasterService addOnMasterService;

    public byte[] generateInvoice(Long bookingId) throws Exception {
        Optional<BookingHeader> bookingOptional = bookingHeaderService.getBookingById(bookingId);
        if (!bookingOptional.isPresent()) {
            throw new RuntimeException("Booking not found with ID: " + bookingId);
        }
        BookingHeader booking = bookingOptional.get();

        List<BookingDetail> bookingDetails = bookingDetailService.getBookingDetailByBookingId(bookingId.intValue());

        Document document = new Document();
        ByteArrayOutputStream out = new ByteArrayOutputStream();
        PdfWriter.getInstance(document, out);

        document.open();

        Font titleFont = FontFactory.getFont(FontFactory.HELVETICA_BOLD, 16);
        Paragraph title = new Paragraph("Invoice", titleFont);
        title.setAlignment(Element.ALIGN_CENTER);
        document.add(title);

        document.add(new Paragraph("Booking ID: " + booking.getBookingId()));
        document.add(new Paragraph("Customer Name: " + booking.getFirstname() + " " + booking.getLastname()));
        document.add(new Paragraph("Email: " + booking.getEmailId()));
        document.add(new Paragraph("Booking Date: " + booking.getBookingdate()));

        PdfPTable table = new PdfPTable(4);
        table.setWidthPercentage(100);
        table.setSpacingBefore(10);
        table.addCell("Add-On ID");
        table.addCell("Add-On Name");
        table.addCell("Rate");
        table.addCell("Total");

        long rentalDays = ChronoUnit.DAYS.between(booking.getStartdate(), booking.getEnddate() ) +1;
        
        double dailyRate = booking.getDailyrate();
        double weeklyRate = booking.getWeeklyrate();
        double monthlyRate = booking.getMonthlyrate();
        
        long months = rentalDays / 30;
        long remainingDaysAfterMonths = rentalDays % 30;
        long weeks = remainingDaysAfterMonths / 7;
        long remainingDays = remainingDaysAfterMonths % 7;

        double totalBookingCost = (months * monthlyRate) + (weeks * weeklyRate) + (remainingDays * dailyRate);
        
        double totalAddonCost = 0;
        for (BookingDetail detail : bookingDetails) {
            AddOnMaster addOn = addOnMasterService.getAddOnById(detail.getAddonId());
            table.addCell(String.valueOf(addOn.getAddonId()));
            table.addCell(addOn.getAddonName());
            table.addCell("$" + addOn.getAddonDailyRate());
            double total = addOn.getAddonDailyRate() * rentalDays;

            table.addCell("$" + total);
            totalAddonCost += total;
        }
        document.add(table);

        double grandTotal = totalBookingCost + totalAddonCost;

        document.add(new Paragraph("Total Booking Cost: $" + totalBookingCost));
        document.add(new Paragraph("Total Add-On Cost: $" + totalAddonCost));
        document.add(new Paragraph("Grand Total: $" + grandTotal));

        document.close();
        return out.toByteArray();
    }
}
