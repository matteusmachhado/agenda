
namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeSMS
{
    public class ClientSendVerificationCodeSMSCommand : BaseCommand
    {
        public string PhoneNumber { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientSendVerificationCodeSMSCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
