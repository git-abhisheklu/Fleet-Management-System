using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface IBookingDetailService
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetails();
        Task<BookingDetail> AddBookingDetails(BookingDetail bookingDetail);
        Task DeleteBooking(long booking_id);
        Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingId(long booking_id);

    }
}
