

using Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail;
using Agenda.Shared.Enums;

namespace Agenda.Domain.Features.Client.Commands.Create
{
    public class CreateCommand : BaseCommand
    {
        public TypeOfCheckEnum TypeOfCheck { get; set; }
        public string From { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
