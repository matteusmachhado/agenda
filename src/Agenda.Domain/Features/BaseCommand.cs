using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Agenda.Domain.Features
{
    public abstract class BaseCommand : IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        
        [JsonIgnore]
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
