using Agenda.Domain.Features.Company.Commands.Create;
using Agenda.WebApi.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Features.Client.Commands.SendSMS
{
    public class ClientVerificationComand : BaseCommand
    {
        public string PhoneNumber { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientVerificationComandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
