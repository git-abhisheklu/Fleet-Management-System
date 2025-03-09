using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Fleet_Management.Models;
using Fleet_Management.DTO;
using Fleet_Management.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fleet_Management.Service;

namespace Fleet_Management.Service
{
    public class BookingHeaderService : IBookingHeaderService
    {
        private readonly FleetDbContext _context;

        public BookingHeaderService(FleetDbContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookingByEmailIdAsync(string emailId)
        {
            return await _context.Bookings
                .Where(b => b.EmailId == emailId)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(long bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .Include(b => b.Cartype)
                .FirstOrDefaultAsync(b => b.BookingId == bookingId);

            if (booking == null)
                throw new Exception($"Booking not found with ID: {bookingId}");

            return booking;
        }

        public async Task DeleteBookingAsync(long bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Booking?> SaveAsync(Booking booking)
        {
            string jsonString = JsonSerializer.Serialize(booking, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);
            //var createdbooking = await _context.Bookings.Include(b => b.BookingDetails).ToListAsync();
            _context.Bookings.Add(booking);
            //_context.Bookings.Add(createdbooking);
            await _context.SaveChangesAsync();

            return booking;
        }


        public async Task<List<BookingDTO>> GetBookingDetailsByEmailIdAsync(string emailId)
        {
            var bookings = await _context.Bookings
                .Where(b => b.EmailId == emailId)
                .Include(b => b.BookingDetails)
                .ToListAsync();

            return bookings.Select(b => new BookingDTO(
                b.BookingId, b.Bookingdate, b.Firstname, b.Lastname, b.EmailId,
                b.Dailyrate, b.Weeklyrate, b.Monthlyrate, b.Startdate, b.Enddate,
                b.PickupHubAddress, b.ReturnHubAddress,
                b.BookingDetails.Select(d => new BookingDetailDTO(d.BookingDetailId, d.AddonId ?? 0, d.AddonRate ?? 0)).ToList()
            )).ToList();
        }

        public async Task<List<BookingDTO>> GetAllBookingsAsync()
        {
            var bookings = await _context.Bookings
                .Include(b => b.BookingDetails)
                .ToListAsync();

            return bookings.Select(b => new BookingDTO(
                b.BookingId, b.Bookingdate, b.Firstname, b.Lastname, b.EmailId,
                b.Dailyrate, b.Weeklyrate, b.Monthlyrate, b.Startdate, b.Enddate,
                b.PickupHubAddress, b.ReturnHubAddress,
                b.BookingDetails.Select(d => new BookingDetailDTO(d.BookingDetailId, d.AddonId ?? 0, d.AddonRate ?? 0)).ToList()
            )).ToList();
        }
    }
}
