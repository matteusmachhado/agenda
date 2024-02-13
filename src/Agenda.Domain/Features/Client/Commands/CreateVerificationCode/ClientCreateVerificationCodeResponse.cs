
using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.CreateVerificationCode
{
    public class ClientCreateVerificationCodeResponse 
    {
        public readonly ValidationResult ValidationResult;
        public readonly string Code;

        public ClientCreateVerificationCodeResponse(ValidationResult validationResult)
        {
            Code = string.Empty;
            ValidationResult = validationResult;
        }

        public ClientCreateVerificationCodeResponse(string code)
        {
            Code = code;
            ValidationResult = new ValidationResult();
        }
    }
}
