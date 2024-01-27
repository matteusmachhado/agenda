using Agenda.Domain.DTOs;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Agenda.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotificationService _notificador;
        protected BaseService(INotificationService notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool ExecutarValidacao<TValidator, TEntity>(TValidator validacao, TEntity entidade) where TValidator : AbstractValidator<TEntity> where TEntity : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
