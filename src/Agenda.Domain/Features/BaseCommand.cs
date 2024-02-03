using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features
{
    public abstract class BaseCommand : IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected BaseCommand()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
