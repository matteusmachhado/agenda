using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Features.Company.Commands.Create
{
    public class CreateCommand : BaseCommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
