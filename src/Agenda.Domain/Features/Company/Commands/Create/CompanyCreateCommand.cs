using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Features.Company.Commands.Create
{
    public class CompanyCreateCommand : BaseCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CompanyCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
