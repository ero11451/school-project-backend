using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;


namespace WebPWrecover.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // No-op for development purposes
        return Task.CompletedTask;
    }
}



public class SmtpEmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;

    public SmtpEmailSender()
    {
        _smtpClient = new SmtpClient("smtp.your-email-provider.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("your-email@example.com", "your-password"),
            EnableSsl = true,
        };
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage("your-email@example.com", email, subject, htmlMessage)
        {
            IsBodyHtml = true
        };

        await _smtpClient.SendMailAsync(mailMessage);
    }
}