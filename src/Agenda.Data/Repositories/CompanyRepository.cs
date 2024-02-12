using Agenda.Data.Contexts;
using Agenda.Data.Interfaces;
using Agenda.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Data.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AgendaDbContext agendaDbContext) : base(agendaDbContext)
        {
        }
    }
}
