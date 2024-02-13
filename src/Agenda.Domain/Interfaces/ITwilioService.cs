
namespace Agenda.Domain.Interfaces
{
    public interface ITwilioService
    {
        Task Verification(string code, string phoneNumber);
    }
}
