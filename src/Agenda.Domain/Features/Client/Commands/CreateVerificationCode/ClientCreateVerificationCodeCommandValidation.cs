using FluentValidation;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCode
{
    public class ClientCreateVerificationCodeCommandValidation : AbstractValidator<ClientCreateVerificationCodeCommand>
    {
        public ClientCreateVerificationCodeCommandValidation()
        {
            RuleFor(c => c.TypeCodeVerify)
                .NotNull();
        }
    }
}
