using Agenda.Data.Interfaces;
using Agenda.Shared.Settings;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;

namespace Agenda.Domain.Features.Client.Commands.VerifyCode
{
    public class ClientVerifyCodeCommandHandler : BaseCommandHandler, IRequestHandler<ClientVerifyCodeCommand, ValidationResult>
    {
        private readonly VerificationCodeSetting _verificationCodeSetting;
        private readonly IVerificationCodeRepository _verificationCodeRepository;

        public ClientVerifyCodeCommandHandler(IUnitOfWork _uow,
            IOptions<VerificationCodeSetting> verificationCodeSetting,
            IVerificationCodeRepository verificationCodeRepository
            ) : base(_uow)
        {
            _verificationCodeSetting = verificationCodeSetting.Value;
            _verificationCodeRepository = verificationCodeRepository;
        }

        public async Task<ValidationResult> Handle(ClientVerifyCodeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var verificationCode = await _verificationCodeRepository.FindCodeUnchecked(request.Code);

            if (verificationCode is null)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, $"Código {request.Code} inválido."));
                return request.ValidationResult;
            }

            if (verificationCode.CreateDate.AddSeconds(_verificationCodeSetting.Timer) < DateTime.Now)
            {
                request.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, $"Código {request.Code} expirou."));
                return request.ValidationResult;
            }

            verificationCode.Checked();

            await Commit();

            return request.ValidationResult;
        }
    }
}
