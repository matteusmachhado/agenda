using Agenda.Domain.Features.Client.Commands.SendVerificationCode;
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
        [HttpPost("verification")]
        public async Task<ActionResult> Send(ClientSendVerificationCodeCommand clientSendVerificationCodeCommand)
        {
            var result = await _mediator.Send(clientSendVerificationCodeCommand);

            return CustomResponse(result);
        }
    }
}
