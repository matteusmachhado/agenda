using FluentValidation;
using PhoneNumbers;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeSMS
{
    public class ClientSendVerificationCodeSMSCommandValidation : AbstractValidator<ClientSendVerificationCodeSMSCommand>
    {
        public ClientSendVerificationCodeSMSCommandValidation()
        {
            RuleFor(c => c.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Must(ValidPhoneNumber)
                .WithMessage("'{PropertyValue}' inválido.");
        }

        private bool ValidPhoneNumber(string phoneNumber)
        {
            var isValid = false;

            try
            {
                var phoneUtil = PhoneNumberUtil.GetInstance();
                var phoneNumberUtil = phoneUtil.Parse(phoneNumber, "BR");
                isValid = phoneUtil.IsValidNumber(phoneNumberUtil);
            }
            catch(Exception ex) 
            {
                // log
            }

            return isValid;
        }
    }
}
