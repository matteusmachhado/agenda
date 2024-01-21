using Agenda.Domain.DTO;
using Agenda.Domain.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificadorService _notifier;

        protected MainController(INotificadorService notifier)
        {
            _notifier = notifier;
        }

        protected bool IsValid()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                errors = _notifier.Notifications().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifier.Handle(new Notification(error.ErrorMessage));
            }

            return CustomResponse();
        }

        protected void NotificationError(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }
    }
}
