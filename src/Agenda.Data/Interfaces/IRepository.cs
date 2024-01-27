using Agenda.Domain.Entities;
using System.Linq.Expressions;

namespace Agenda.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> All();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);   
    }
}
