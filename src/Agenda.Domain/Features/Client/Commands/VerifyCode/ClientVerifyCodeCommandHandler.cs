using Agenda.Data.Interfaces;
using Agenda.Domain.Features.Client.Commands.Create;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Notifications.Client;
using Agenda.Shared.DTOs;
using Agenda.Shared.Enums;
using Agenda.Shared.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Agenda.Domain.Features.Client.Commands.VerifyCode
{
    public class ClientVerifyCodeCommandHandler : BaseCommandHandler, IRequestHandler<ClientVerifyCodeCommand, string>
    {
        private readonly VerificationCodeSettings _verificationCodeSetting;
        private readonly IVerificationCodeRepository _verificationCodeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly INotificationService _notifier;
        private readonly IMediator _mediator;

        public ClientVerifyCodeCommandHandler(IUnitOfWork _uow,
            IOptions<VerificationCodeSettings> verificationCodeSetting,
            IVerificationCodeRepository verificationCodeRepository,
            UserManager<IdentityUser> userManager,
            INotificationService notifier,
            IMediator mediator
            ) : base(_uow)
        {
            _verificationCodeSetting = verificationCodeSetting.Value;
            _verificationCodeRepository = verificationCodeRepository;
            _userManager = userManager;
            _notifier = notifier;
            _mediator = mediator;
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

            var from = verificationCode.GetTypeOfCheck();

            var client = await FindClientUserAsync(verificationCode.TypeCheck, from);
            if (client is null) await _mediator.Send(new CreateCommand() 
            { 
                TypeOfCheck = verificationCode.TypeCheck, 
                From = from 
            });

            await _mediator.Publish(new ClientVerificationCodeEvent(verificationCode.TypeCheck, from));

            return from;
        }

        private async Task<IdentityUser> FindClientUserAsync(TypeOfCheckEnum typeOfCheck, string from)
        {
            IdentityUser user = null;

            switch (typeOfCheck)
            {
                case TypeOfCheckEnum.SMS:
                    user = await _userManager.FindByEmailAsync(from);
                    break;
                case TypeOfCheckEnum.Email:
                    user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber != null && u.PhoneNumber.Equals(from));
                    break;
            }

            return user;
        }
    }
}
