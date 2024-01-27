﻿using Agenda.Data.Context;
using Agenda.Data.Mapping;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Agenda.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AgendaDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(AgendaDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> All()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.AddAsync(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
