using Agenda.Domain.Features.Company.Commands.Create;
using Agenda.Domain.Interfaces;
using Agenda.Entities.ViewModels;
using Agenda.Entities.ViewModels.Auth;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/company")]
    public class CompanyController : MainController
    {
        private readonly IMediator _mediator;

        public CompanyController(
            INotificationService notifier,
            IMediator mediator
            ) : base(notifier)
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
