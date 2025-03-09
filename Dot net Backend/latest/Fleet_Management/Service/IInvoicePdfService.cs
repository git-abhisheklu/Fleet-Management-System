
namespace Fleet_Management.Service
{
    public interface IInvoicePdfService
    {
        Task<byte[]> GenerateInvoiceAsync(long bookingId);
    }
}
