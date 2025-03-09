using Microsoft.AspNetCore.Mvc;

using Fleet_Management.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Fleet_Management.DTO;
using Fleet_Management.Service;

namespace FleetManagement.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookingHeaderController : ControllerBase
    {
        private readonly IBookingHeaderService _bookingHeaderService;

        public BookingHeaderController(IBookingHeaderService bookingHeaderService)
        {
            _bookingHeaderService = bookingHeaderService;
        }

        [HttpGet("bookings")]
        public async Task<ActionResult<List<BookingDTO>>> GetAllBookings()
        {
            var bookings = await _bookingHeaderService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpPost("addbooking")]
       
        public async Task<ActionResult<Booking>> Save([FromBody] Booking booking)
        {

            try
            {
                var savedBooking = await _bookingHeaderService.SaveAsync(booking);
                return Ok(savedBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("booking/email/{emailId}")]
        public async Task<ActionResult<List<BookingDTO>>> GetBookingByEmailId(string emailId)
        {
            var bookings = await _bookingHeaderService.GetBookingDetailsByEmailIdAsync(emailId);
            return Ok(bookings);
        }

        [HttpDelete("deletebooking/{bookingId}")]
        public async Task<ActionResult> DeleteBooking(long bookingId)
        {
            try
            {
                await _bookingHeaderService.DeleteBookingAsync(bookingId);
                return Ok("Booking deleted successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
