using Agenda.Data.Interfaces;
using FluentValidation.Results;

namespace Agenda.Domain.Features
{
    public abstract class BaseCommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected ValidationResult ValidationResult;

        public BaseCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> Commit()
        {
            if (!await _uow.Commit()) AddError("Erro ao persistir os dados.");

            return ValidationResult;
        }
    }
}
