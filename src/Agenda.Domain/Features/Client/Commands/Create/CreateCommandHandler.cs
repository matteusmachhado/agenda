using Agenda.Data.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.Create
{
    public class CreateCommandHandler : BaseCommandHandler, IRequestHandler<CreateCommand, ValidationResult>
    {
        public CreateCommandHandler(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<ValidationResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;



            return request.ValidationResult;
        }
    }
}
