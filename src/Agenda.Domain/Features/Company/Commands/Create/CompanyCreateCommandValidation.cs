using FluentValidation;

namespace Agenda.Domain.Features.Company.Commands.Create
{
    public class CompanyCreateCommandValidation : AbstractValidator<CompanyCreateCommand>
    {
        public CompanyCreateCommandValidation()
        {

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} obrigatório");
        }
    }
}
