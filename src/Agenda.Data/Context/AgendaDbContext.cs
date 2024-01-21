using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Agenda.Data.Context
{
    public class AgendaDbContext : DbContext
    {
        public AgendaDbContext(DbContextOptions<AgendaDbContext> dbContextOptions): base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
