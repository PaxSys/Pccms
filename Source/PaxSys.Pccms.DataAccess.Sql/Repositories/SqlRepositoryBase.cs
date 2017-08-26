using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSys.Pccms.Domain;
using PaxSys.Pccms.Domain.Models;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.DataAccess.Sql.Repositories
{
    public class SqlRepositoryBase<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        protected TContext Context { get; }

        public SqlRepositoryBase(TContext context)
        {
            Guard.ArgumentNotDefault(context, nameof(context));
            
            Context = context;
        }

        public TEntity Get(int id)
        {
            Guard.ArgumentNotDefault(id, nameof(id));
            
            return Context.Set<TEntity>().Find(id);
        }

        public TEntity[] Get()
        {
            return Context.Set<TEntity>().ToArray();
        }

        public TEntity[] Find(Expression<Func<TEntity, bool>> predicate)
        {
            Guard.ArgumentNotDefault(predicate, nameof(predicate));
            
            return Context.Set<TEntity>().Where(predicate).ToArray();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            Guard.ArgumentNotDefault(predicate, nameof(predicate));
            
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Store(TEntity model)
        {
            Guard.ArgumentNotDefault(model, nameof(model));
            
            Context.Set<TEntity>().Add(model);
            Context.SaveChanges();
        }

        public void AddRange(TEntity[] models)
        {
            Guard.ArgumentNotDefault(models, nameof(models));
            
            Context.Set<TEntity>().AddRange(models);
            Context.SaveChanges();
        }

        public void Remove(TEntity model)
        {
            Guard.ArgumentNotDefault(model, nameof(model));
            
            Context.Set<TEntity>().Remove(model);
            Context.SaveChanges();
        }
    }
}
