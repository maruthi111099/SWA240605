using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SWA240605_WebAPI.Application.DTOs;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Domain.Settings;

namespace SWA240605_WebAPI.Shared.Services
{
    public class EmailService : IEmailService
    {
        public MailSetting _mailSettings { get; }

        public EmailService(IOptions<MailSetting> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                // Create message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                email.From.Add(MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom));
                //email.To.Add(MailboxAddress.Parse(request.To));
                email.To.Add(MailboxAddress.Parse("iyyappanr@gmail.com"));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.None);
                //smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (System.Exception)
            {
                throw;
            }
        }


    }
}
