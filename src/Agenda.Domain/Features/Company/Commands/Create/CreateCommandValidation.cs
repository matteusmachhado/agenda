using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Features.Company.Commands.Create
{
    public class CreateCommandValidation : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidation()
        {

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Company name must be set");
        }
    }
}
