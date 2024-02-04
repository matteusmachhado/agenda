
namespace Agenda.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
