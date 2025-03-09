using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookingDetailController : ControllerBase
    {
        private readonly IBookingDetailService _bookingDetailService;

        public BookingDetailController(IBookingDetailService bookingDetailService)
        {
            _bookingDetailService = bookingDetailService;
        }
        [HttpGet("bookingdetails")]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetALlBookingDetails()
        {
            var booking = await _bookingDetailService.GetBookingDetails();
            return Ok(booking);
        }

        [HttpPost("addbookingdetails")]
        public async Task<ActionResult<BookingDetail>> AddBookingDetails([FromBody] BookingDetail bookingDetail)
        {
            var createdBooking = await _bookingDetailService.AddBookingDetails(bookingDetail);
            return CreatedAtAction(nameof(GetALlBookingDetails), new { id = createdBooking.BookingId }, createdBooking);
        }

        [HttpDelete("bookingdetails/{booking_id}")]

        public async Task<IActionResult> DeleteBookingDetail(long booking_id)
        {
            await _bookingDetailService.DeleteBooking(booking_id);
            return Ok("Booking Detail deleted successfully!");

        }
        [HttpGet("bookingdetails/booking_id/{bookingId}")]
        public async Task<ActionResult<List<BookingDetail>>> GetBookingDetailByBookingId(long bookingId)
        {
            var bookings = await _bookingDetailService.GetBookingDetailsByBookingId(bookingId);
            return Ok(bookings);
        }
    }

}
