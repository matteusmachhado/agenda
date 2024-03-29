﻿using Agenda.Entities.Base;
using System.Linq.Expressions;

namespace Agenda.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> All();
        IQueryable<TEntity> AsQueryable();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);   
    }
}
