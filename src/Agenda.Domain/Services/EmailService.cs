using Agenda.Domain.Interfaces;
using Agenda.Shared.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace Agenda.Domain.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly EmailSettings _emailSettings;

        public EmailService(ILogger<EmailService> logger,
            IOptions<EmailSettings> emailSettings) 
        {
            _logger = logger;
            _emailSettings = emailSettings.Value;
        }

        public async Task Send(MailMessage message)
        {
            using (var smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port))
            {
                smtp.Credentials = new NetworkCredential(_emailSettings.Login, _emailSettings.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = _emailSettings.EnableSsl;
                smtp.SendCompleted += ClienteSendCompleted;

                message.From = new MailAddress(_emailSettings.From);

                await smtp.SendMailAsync(message);
            }
        }

        private void ClienteSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error is not null) _logger.LogError(e.Error, $"Error {e.Error.Message}");

            ((SmtpClient)(sender)).Dispose();
        }
    }
}
