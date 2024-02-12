using Agenda.Domain.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Agenda.Shared.DTOs;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificationService _notifier;
        protected Guid UserId { get; set; }
        protected string UserName { get; set; }

        protected BaseController(INotificationService notifier,
            IUser user)
        {
            _notifier = notifier;

            if (user.IsAuthenticated())
            {
                UserId = user.GetUserId();
                UserName = user.GetUserName();
            }
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
                _notifier.Handle(new NotificationDto(error.ErrorMessage));
            }

            return CustomResponse();
        }

        protected void NotificationError(string mensagem)
        {
            _notifier.Handle(new NotificationDto(mensagem));
        }
    }
}
