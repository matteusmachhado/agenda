using Agenda.Data.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Enums;
using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail
{
    public class ClientSendVerificationCodeEmailCommandHandler : BaseCommandHandler, IRequestHandler<ClientSendVerificationCodeEmailCommand, ValidationResult>
    {
        private readonly IVerificationCodeService _verificationCodeService;

        public ClientSendVerificationCodeEmailCommandHandler(IUnitOfWork _uow,
            IVerificationCodeService verificationCodeService
            ) : base(_uow)
        {
            _verificationCodeService = verificationCodeService;
        }

        public async Task<ValidationResult> Handle(ClientSendVerificationCodeEmailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var code = await _verificationCodeService.CreateVerificationCodeEmail(request.Email, TypeOfVerificarionCodeEnum.Numeric);


            return request.ValidationResult;
        }
    }
}
