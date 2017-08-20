using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSys.Pcmms.Utils;

namespace PaxSys.Pccms.DataAccess.Sql.Repositories
{
    public class SqlRepositoryBase<TContext, TEntity>  
        where TContext : DbContext
        where TEntity : class
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

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            Guard.ArgumentNotDefault(predicate, nameof(predicate));
            
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            Guard.ArgumentNotDefault(predicate, nameof(predicate));
            
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Add(TEntity model)
        {
            Guard.ArgumentNotDefault(model, nameof(model));
            
            Context.Set<TEntity>().Add(model);
            Context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> models)
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
