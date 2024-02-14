using Agenda.Data.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Enums;
using FluentValidation.Results;
using MediatR;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeSMS
{
    public class ClientSendVerificationCodeSMSCommandHandler : BaseCommandHandler, IRequestHandler<ClientSendVerificationCodeSMSCommand, ValidationResult>
    {
        private readonly ITwilioService _twilioService;
        private readonly IVerificationCodeService _verificationCodeService;

        public ClientSendVerificationCodeSMSCommandHandler(IUnitOfWork _uow,
            ITwilioService twilioService,
            IVerificationCodeService verificationCodeService
            ) : base(_uow)
        {
            _twilioService = twilioService;
            _verificationCodeService = verificationCodeService;
        }

        public async Task<ValidationResult> Handle(ClientSendVerificationCodeSMSCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var code = await _verificationCodeService.CreateVerificationCodeSMS(request.PhoneNumber, TypeOfVerificarionCodeEnum.Numeric);

            await _twilioService.SendVerificationCode(code, request.PhoneNumber);

            return request.ValidationResult;
        }
    }
}
