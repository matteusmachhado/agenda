
namespace Agenda.Domain.Interfaces
{
    public interface ITwilioService
    {
        Task SendVerificationCode(string code, string phoneNumber);
    }
}
