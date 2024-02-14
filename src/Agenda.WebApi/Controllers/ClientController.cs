using Agenda.Domain.Features.Client.Commands.SendVerificationCodeEmail;
using Agenda.Domain.Features.Client.Commands.SendVerificationCodeSMS;
using Agenda.Domain.Features.Client.Commands.VerifyCode;
using Agenda.Domain.Interfaces;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/client")]
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;

        public ClientController(INotificationService notifier,
            IMediator mediator,
            IUser user) : base(notifier, user)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("send-verification-code-sms")]
        public async Task<ActionResult> SendVerificationCodeSMS(ClientSendVerificationCodeSMSCommand clientSendVerificationCodeCommand)
        {
            var result = await _mediator.Send(clientSendVerificationCodeCommand);

            return CustomResponse(result);
        }

        [AllowAnonymous]
        [HttpPost("send-verification-code-email")]
        public async Task<ActionResult> SendVerificationCodeEmail(ClientSendVerificationCodeEmailCommand clientSendVerificationCodeEmailCommand)
        {
            var result = await _mediator.Send(clientSendVerificationCodeEmailCommand);

            return CustomResponse(result);
        }

        [AllowAnonymous]
        [HttpPost("verify")]
        public async Task<ActionResult> Verify(ClientVerifyCodeCommand clientVerifyCodeCommand)
        {
            var result = await _mediator.Send(clientVerifyCodeCommand);

            return CustomResponse(result);
        }
    }
}
