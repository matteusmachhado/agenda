using Agenda.Data.Contexts;
using Agenda.Data.Interfaces;
using Agenda.Entities;

namespace Agenda.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(AgendaDbContext agendaDbContext) : base(agendaDbContext)
        {

        }
    }
}
