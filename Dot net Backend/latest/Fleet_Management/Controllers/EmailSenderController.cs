using Fleet_Management.Models;
using Fleet_Management.Service;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailService _emailService; 
        public EmailSenderController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid email request.");
            }
            try
            {
                await _emailService.SendEmailAsync(request);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: { ex.Message}");
            }
        }
    }
}