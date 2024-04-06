using System.Net.Mail;

namespace Agenda.Domain.Interfaces
{
    public interface IEmailService
    {
        Task Send(MailMessage message);
    }
}
