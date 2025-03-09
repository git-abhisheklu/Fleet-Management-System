using Fleet_Management.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoicePdfService _invoicePdfService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoicePdfService invoicePdfService, ILogger<InvoiceController> logger)
        {
            _invoicePdfService = invoicePdfService;
            _logger = logger;
        }

        [HttpGet("generate/{bookingId}")]
        public async Task<IActionResult> GenerateInvoice(long bookingId)
        {
            try
            {
                // Generate the invoice asynchronously
                var invoicePdf = await _invoicePdfService.GenerateInvoiceAsync(bookingId);
                if (invoicePdf == null || invoicePdf.Length == 0)
                {
                    return NotFound();
                }

                // Set the Content-Disposition header
                Response.Headers.Append("Content-Disposition", "inline; filename=invoice.pdf");
                
                // Return the PDF as a File result with appropriate content type
                return File(invoicePdf, MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the invoice for bookingId: {BookingId}", bookingId);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
