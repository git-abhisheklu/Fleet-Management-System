using Fleet_Management.Models;

namespace Fleet_Management.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}