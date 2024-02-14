
using Agenda.Domain.Features.Client.Queries.VerifyCode;

namespace Agenda.Domain.Features.Client.Commands.VerifyCode
{
    public class ClientVerifyCodeCommand : BaseCommand
    {
        public string Code { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientVerifyCodeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
