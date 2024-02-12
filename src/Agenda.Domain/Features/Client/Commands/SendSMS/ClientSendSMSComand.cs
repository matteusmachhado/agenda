using Agenda.Domain.Features.Company.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Features.Client.Commands.SendSMS
{
    public class ClientSendSMSComand : BaseCommand
    {
        public string Phone { get; set; }
        public string Description { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ClientSendSMSComandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
