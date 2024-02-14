using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Agenda.Domain.Features.Client.Queries.FindVerificationCode
{
    public class ClientFindVerificationCodeQuery : IRequest<ClientFindVerificationCodeResponse>
    {
        public string Code { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClientFindVerificationCodeQueryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
