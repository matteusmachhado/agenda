using Agenda.Shared.DTOs;
using Agenda.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Agenda.Entities.Base;
using Agenda.Data.Interfaces;

namespace Agenda.Domain.Services
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _uow;

        private readonly INotificationService _notificador;

        protected BaseService(INotificationService notificador,
            IUnitOfWork uow)
        {
            _uow = uow;
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
            _notificador.Handle(new NotificationDto(mensagem));
        }

        protected bool ExecutarValidacao<TValidator, TEntity>(TValidator validacao, TEntity entidade) where TValidator : AbstractValidator<TEntity> where TEntity : BaseEntity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }

        protected async Task Commit()
        {
            await _uow.Commit();
        }
    }
}
