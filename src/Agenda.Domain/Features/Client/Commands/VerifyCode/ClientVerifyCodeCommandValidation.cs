using Agenda.Domain.Features.Client.Commands.VerifyCode;
using FluentValidation;

namespace Agenda.Domain.Features.Client.Queries.VerifyCode
{
    public class ClientVerifyCodeCommandValidation : AbstractValidator<ClientVerifyCodeCommand>
    {
        public ClientVerifyCodeCommandValidation()
        {
            RuleFor(c => c.Code)
                .NotNull()
                .NotEmpty();
        }
    }
}
