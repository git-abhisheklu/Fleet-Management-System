using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fleet_Management.Models;
using Fleet_Management.DTO;
using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface IBookingHeaderService
    {
        Task<List<Booking>> GetBookingByEmailIdAsync(string emailId);
        Task DeleteBookingAsync(long bookingId);
        Task<Booking> SaveAsync(Booking bookingDto);
        Task<List<BookingDTO>> GetBookingDetailsByEmailIdAsync(string emailId);
        Task<Booking> GetBookingByIdAsync(long bookingId);
        Task<List<BookingDTO>> GetAllBookingsAsync();
    }
}