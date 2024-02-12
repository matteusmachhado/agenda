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
    [Route("api/v{version:apiVersion}/company")]
    public class CompanyController : BaseController
    {
        private readonly IMediator _mediator;

        public CompanyController(
            INotificationService notifier,
            IMediator mediator, 
            IUser user
            ) : base(notifier,
                user)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(CompanyCreateCommand createCommand)
        {
            var result = await _mediator.Send(createCommand);

            return CustomResponse(result);
        }
    }
}
