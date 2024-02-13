using Agenda.Domain.Features.Client.Commands.CreateVerificationCode;
using Agenda.Shared.Enums;
using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCode
{
    public class ClientCreateVerificationCodeCommand : IRequest<ClientCreateVerificationCodeResponse>
    {
        public TypeCodeVerifyEnum TypeCodeVerify { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClientCreateVerificationCodeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
