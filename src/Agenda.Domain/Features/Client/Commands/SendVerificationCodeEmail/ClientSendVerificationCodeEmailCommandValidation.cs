using FluentValidation;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail
{
    public class ClientSendVerificationCodeEmailCommandValidation : AbstractValidator<ClientSendVerificationCodeEmailCommand>
    {
        public ClientSendVerificationCodeEmailCommandValidation()
        {
            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
    }
}
