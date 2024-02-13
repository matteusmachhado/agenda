
namespace Agenda.Domain.Features.Client.Commands.SendVerificationCode
{
    public class ClientSendVerificationCodeCommand : BaseCommand
    {
        public string PhoneNumber { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientSendVerificationCodeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
