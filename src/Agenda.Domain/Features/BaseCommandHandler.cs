using Agenda.Data.Interfaces;
using FluentValidation.Results;

namespace Agenda.Domain.Features
{
    public abstract class BaseCommandHandler
    {
        protected ValidationResult ValidationResult;

        protected BaseCommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("An error occurred while trying to persist data");

            return ValidationResult;
        }
    }
}
