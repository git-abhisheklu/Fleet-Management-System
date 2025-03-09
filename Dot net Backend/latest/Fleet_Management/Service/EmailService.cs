using Fleet_Management.Models;
using System.Net.Mail;
using System.Net;
using Fleet_Management.Exceptions;

namespace Fleet_Management.Service
{
    public class EmailService: IEmailService
    {
        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            try
            {
                var smtpClient = new SmtpClient(emailRequest.SmtpServer)
                {
                    Port = emailRequest.Port,
                    Credentials = new NetworkCredential(emailRequest.Username, emailRequest.Password),
                    EnableSsl = true,
                    UseDefaultCredentials = false
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailRequest.From),
                    Subject = emailRequest.Subject,
                    Body = emailRequest.Body,
                    IsBodyHtml = true
                }; foreach (var recipient in emailRequest.To)
                {
                    mailMessage.To.Add(recipient);
                }
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException smtpEx)
            {
                throw new ApiException("SMTP error occurred", smtpEx);
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to send email", ex);
            }
        }
    }
}
