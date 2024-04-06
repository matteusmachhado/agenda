using Agenda.Data.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Entities;
using Agenda.Shared.Enums;
using Agenda.Shared.Utils;
using FluentValidation.Results;
using MediatR;
using System.Net.Mail;
using System.Text;

namespace Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail
{
    public class ClientSendVerificationCodeEmailCommandHandler : BaseCommandHandler, IRequestHandler<ClientSendVerificationCodeEmailCommand, ValidationResult>
    {
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IEmailService _emailService;
        

        public ClientSendVerificationCodeEmailCommandHandler(IUnitOfWork _uow,
            IVerificationCodeService verificationCodeService,
            IEmailService emailService
            ) : base(_uow)
        {
            _verificationCodeService = verificationCodeService;
            _emailService = emailService;
        }

        public async Task<ValidationResult> Handle(ClientSendVerificationCodeEmailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var code = await _verificationCodeService.CreateVerificationCodeEmail(request.Email, TypeOfVerificarionCodeEnum.Numeric);

            var mailMessage = GetTemplateMailMessage(request.Email, code);

            await _emailService.Send(mailMessage);

            return request.ValidationResult;
        }

        private MailMessage GetTemplateMailMessage(string email, string code) 
        {
            var template = FilesUtil.LoadTemplateEmail("VerificationCode");
            var body = template.ReplaceVariablesTemplate(new Dictionary<string, string>()
            {
                { "verification_code", code }
            });

            var message = new MailMessage();
            message.To.Add(email);
            message.Subject = "Código de Verificação para Agenda";
            message.Body = body;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;

            return message;
        }
    }
}
