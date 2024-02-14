using FluentValidation;

namespace Agenda.Domain.Features.Client.Queries.FindVerificationCode
{
    public class ClientFindVerificationCodeQueryValidation : AbstractValidator<ClientFindVerificationCodeQuery>
    {
        public ClientFindVerificationCodeQueryValidation()
        {
            RuleFor(c => c.Code)
                .NotNull();
        }
    }
}
