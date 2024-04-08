using Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Features.Client.Commands.Create
{
    internal class CreateCommandValidation : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidation()
        {
            RuleFor(c => c.TypeOfCheck)
                .NotNull();

            RuleFor(c => c.From)
                .NotEmpty()
                .NotNull();
        }
    }
}
