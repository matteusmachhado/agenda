using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Company.Commands.Create
{
    internal class CreateCommandHandler : BaseCommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {


            throw new NotImplementedException();
        }
    }
}
