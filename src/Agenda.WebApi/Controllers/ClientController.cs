using Agenda.Domain.Features.Client.Commands.SendSMS;
using Agenda.Domain.Features.Company.Commands.Create;
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
        [HttpPost("send-sms")]
        public async Task<ActionResult> Send(ClientSendSMSComand SendSMSComand)
        {
            var result = await _mediator.Send(SendSMSComand);

            return CustomResponse(result);
        }
    }
}
