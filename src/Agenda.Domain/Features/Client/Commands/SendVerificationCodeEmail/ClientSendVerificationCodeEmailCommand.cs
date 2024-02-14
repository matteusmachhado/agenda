
namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail
{
    public class ClientSendVerificationCodeEmailCommand : BaseCommand
    {
        public string Email { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientSendVerificationCodeEmailCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
