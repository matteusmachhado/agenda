using FluentValidation;

namespace Agenda.Domain.Features.Client.Commands.SendSMS
{
    public class ClientSendSMSComandValidation : AbstractValidator<ClientSendSMSComand>
    {
        public ClientSendSMSComandValidation()
        {
            RuleFor(c => c.Phone)
                .NotEmpty()
                .WithMessage("{PropertyName} obrigatório");
        }
    }
}
