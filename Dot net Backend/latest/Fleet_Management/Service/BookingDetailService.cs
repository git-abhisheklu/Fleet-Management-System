using Fleet_Management.Repository;
using Fleet_Management.Models;
using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Fleet_Management.Service;

namespace Fleet_Management.Service
{
    public class BookingDetailService : IBookingDetailService
    {

        private readonly FleetDbContext _context;

        public BookingDetailService(FleetDbContext context)
        {
            _context = context;
        }
        public async Task<BookingDetail> AddBookingDetails(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            await _context.SaveChangesAsync();
            return bookingDetail;
        }

        public async Task DeleteBooking(long booking_id)
        {
            var booking = await _context.BookingDetails.FindAsync(booking_id);
            if (booking != null)
            {
                _context.BookingDetails.Remove(booking);
                await _context.SaveChangesAsync();
            }
        
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetails()
        {
            return await _context.BookingDetails.ToListAsync();

        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailsByBookingId(long booking_id)
        {
            return await _context.BookingDetails.Where(b => b.BookingDetailId == booking_id).ToListAsync();

        }
    }
}
