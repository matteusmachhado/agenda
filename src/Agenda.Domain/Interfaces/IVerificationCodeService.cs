

using Agenda.Entities;
using Agenda.Shared.Enums;

namespace Agenda.Domain.Interfaces
{
    public interface IVerificationCodeService
    {
        Task<string> CreateVerificationCodeSMS(string phoneNumber, TypeOfVerificarionCodeEnum typeOfVerificarionCode);
        Task<string> CreateVerificationCodeEmail(string email, TypeOfVerificarionCodeEnum typeOfVerificarionCode);

    }
}
