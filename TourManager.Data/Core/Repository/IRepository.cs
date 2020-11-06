using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TourManager.Data.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        
        IEnumerable<TEntity> GetAll();
        
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        
        int AddWithIdentity(TEntity entity);
        
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        
        IQueryable<TEntity> IncludEntities(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector)
            where TEntity : Core.Domain.TEntity;
        
    }
}