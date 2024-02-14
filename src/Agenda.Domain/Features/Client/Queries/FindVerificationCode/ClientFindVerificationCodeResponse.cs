
using Agenda.Shared.Enums;
using FluentValidation.Results;

namespace Agenda.Domain.Features.Client.Queries.FindVerificationCode
{
    public class ClientFindVerificationCodeResponse
    {
        public readonly ValidationResult ValidationResult;
        public string Code { get; set; }
        public TypeOfCheckEnum TypeCheck { get; set; }
        public DateTime? DateCheck { get; set; }

        public ClientFindVerificationCodeResponse()
        {
            
        }

        public ClientFindVerificationCodeResponse(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
