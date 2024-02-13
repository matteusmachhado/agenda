using Agenda.WebApi.Configurations;
using FluentValidation;
using PhoneNumbers;

namespace Agenda.Domain.Features.Client.Commands.SendSMS
{
    public class ClientVerificationComandValidation : AbstractValidator<ClientVerificationComand>
    {
        public ClientVerificationComandValidation()
        {
            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
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
