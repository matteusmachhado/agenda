
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
