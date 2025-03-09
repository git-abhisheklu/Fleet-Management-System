using System;
using System.IO;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using System.Text;
using Fleet_Management.Service;


namespace Fleet_Management.Service
{
    public class InvoicePdfService : IInvoicePdfService
    {
        private readonly IBookingHeaderService _bookingHeaderService;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly AddOnMasterService _addOnMasterService;

        public InvoicePdfService(IBookingHeaderService bookingHeaderService,
                                 IBookingDetailService bookingDetailService,
                                 IAddOnMasterService addOnMasterService)
        {
            _bookingHeaderService = bookingHeaderService;
            _bookingDetailService = bookingDetailService;
            _addOnMasterService = (AddOnMasterService?)addOnMasterService;
        }

        public async Task<byte[]> GenerateInvoiceAsync(long bookingId)
        {
            var booking = await _bookingHeaderService.GetBookingByIdAsync(bookingId);
            if (booking == null)
                throw new Exception("Booking not found with ID: " + bookingId);

            var bookingDetails = await _bookingDetailService.GetBookingDetailsByBookingId((int)bookingId);

            using (var stream = new MemoryStream())
            {
                var writerProperties = new WriterProperties();

                // Encryption Setup
                var writer = new PdfWriter(stream, new WriterProperties()
            .SetStandardEncryption(
                Encoding.UTF8.GetBytes("userPassword"), 
                Encoding.UTF8.GetBytes("ownerPassword"), 
                EncryptionConstants.ALLOW_PRINTING, 
                EncryptionConstants.ENCRYPTION_AES_128 
            ));
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                var title = new Paragraph("Invoice")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(16)
                                .SetFont(boldFont);
                document.Add(title);

                document.Add(new Paragraph("Booking ID: " + booking.BookingId));
                document.Add(new Paragraph("Customer Name: " + booking.Firstname + " " + booking.Lastname));
                document.Add(new Paragraph("Email: " + booking.EmailId));
                document.Add(new Paragraph("Booking Date: " + booking.Bookingdate));

                var table = new Table(4)
                                .UseAllAvailableWidth()
                                .SetMarginTop(10);
                table.AddHeaderCell("Add-On ID");
                table.AddHeaderCell("Add-On Name");
                table.AddHeaderCell("Rate");
                table.AddHeaderCell("Total");

                var rentalDays = (booking.Enddate.ToDateTime(TimeOnly.MinValue) -
                                  booking.Startdate.ToDateTime(TimeOnly.MinValue)).Days + 1;

                double dailyRate = booking.Dailyrate ?? 0;
                double weeklyRate = booking.Weeklyrate ?? 0;
                double monthlyRate = booking.Monthlyrate ?? 0;

                long months = rentalDays / 30;
                long remainingDaysAfterMonths = rentalDays % 30;
                long weeks = remainingDaysAfterMonths / 7;
                long remainingDays = remainingDaysAfterMonths % 7;

                double totalBookingCost = (months * monthlyRate) + (weeks * weeklyRate) + (remainingDays * dailyRate);

                double totalAddonCost = 0;
                foreach (var detail in bookingDetails)
                {
                    var addOn = await _addOnMasterService.GetAddOnByIdAsync(detail.AddonId ?? 0);
                    if (addOn != null)
                    {
                        table.AddCell(addOn.AddonId.ToString());
                        table.AddCell(addOn.AddonName);
                        table.AddCell("$" + addOn.AddonDailyRate);
                        double total = (addOn.AddonDailyRate ?? 0) * rentalDays;
                        table.AddCell("$" + total);
                        totalAddonCost += total;
                    }
                }
                document.Add(table);

                double grandTotal = totalBookingCost + totalAddonCost;

                document.Add(new Paragraph("Total Booking Cost: $" + totalBookingCost));
                document.Add(new Paragraph("Total Add-On Cost: $" + totalAddonCost));
                document.Add(new Paragraph("Grand Total: $" + grandTotal));

                document.Close();
                return stream.ToArray();
            }
        }
    }
}