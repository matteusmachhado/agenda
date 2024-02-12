using Agenda.Data.Interfaces;
using FluentValidation.Results;

namespace Agenda.Domain.Features
{
    public abstract class BaseCommandHandler
    {
        private readonly IUnitOfWork _uow;

        public BaseCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected async Task Commit()
        {
            await _uow.Commit();
        }
    }
}
