using Agenda.Data.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Shared.DTOs;
using Agenda.Shared.Enums;
using Agenda.Shared.Settings;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;

namespace Agenda.Domain.Features.Client.Commands.VerifyCode
{
    public class ClientVerifyCodeCommandHandler : BaseCommandHandler, IRequestHandler<ClientVerifyCodeCommand, string>
    {
        private readonly VerificationCodeSetting _verificationCodeSetting;
        private readonly IVerificationCodeRepository _verificationCodeRepository;
        private readonly INotificationService _notifier;

        public ClientVerifyCodeCommandHandler(IUnitOfWork _uow,
            IOptions<VerificationCodeSetting> verificationCodeSetting,
            IVerificationCodeRepository verificationCodeRepository,
            INotificationService notifier
            ) : base(_uow)
        {
            _verificationCodeSetting = verificationCodeSetting.Value;
            _verificationCodeRepository = verificationCodeRepository;
            _notifier = notifier;
        }

        public async Task<string> Handle(ClientVerifyCodeCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Code))
            {
                _notifier.Handle(new NotificationDto("Código não preenchido"));
                
                return string.Empty;
            }

            var verificationCode = await _verificationCodeRepository.FindCodeUnchecked(request.Code);

            if (verificationCode is null)
            {
                _notifier.Handle(new NotificationDto($"Código {request.Code} inválido."));
                
                return string.Empty;
            }

            if (verificationCode.CreateDate.AddSeconds(_verificationCodeSetting.Timer) < DateTime.Now)
            {
                _notifier.Handle(new NotificationDto($"Código {request.Code} expirou."));
                
                return string.Empty;
            }

            verificationCode.Checked();

            await Commit();

            return verificationCode.TypeCheck == TypeOfCheckEnum.SMS ? verificationCode.PhoneNumber : verificationCode.Email;
        }
    }
}
