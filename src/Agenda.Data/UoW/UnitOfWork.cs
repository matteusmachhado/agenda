using Agenda.Data.Context;
using Agenda.Data.Interfaces;

namespace Agenda.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgendaDbContext _context;

        public UnitOfWork(AgendaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
