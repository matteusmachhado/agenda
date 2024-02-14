using Agenda.Data.Contexts;
using Agenda.Data.Interfaces;
using Agenda.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Repositories
{
    public class VerificationCodeRepository : IVerificationCodeRepository
    {
        protected readonly AgendaDbContext _agendaDbContext;

        public VerificationCodeRepository(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
        }

        public void Add(VerificationCode entity)
        {
            _agendaDbContext.VerificationCodes.Add(entity);
        }

        public Task<VerificationCode> FindCodeUnchecked(string code)
        {
            return _agendaDbContext.VerificationCodes.FirstOrDefaultAsync(c => c.Code.Equals(code) && !c.DateCheck.HasValue);
        }
    }
}
