using Agenda.Data.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Enums;
using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCode
{
    public class ClientSendVerificationCodeCommandHandler : BaseCommandHandler, IRequestHandler<ClientSendVerificationCodeCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly ITwilioService _twilioService;

        public ClientSendVerificationCodeCommandHandler(IUnitOfWork _uow,
            IMediator mediator,
            ITwilioService twilioService
            ) : base(_uow)
        {
            _mediator = mediator;
            _twilioService = twilioService;
        }

        public async Task<ValidationResult> Handle(ClientSendVerificationCodeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var command = new ClientCreateVerificationCodeCommand() { TypeVerificarionCode = TypeVerificarionCodeEnum.Numeric };
            var result = await _mediator.Send(command);
            var code = result.Code;

            await _twilioService.SendVerificationCode(code, request.PhoneNumber);

            return request.ValidationResult;
        }
    }
}
