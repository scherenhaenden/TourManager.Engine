using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Core.Repository;

namespace TourManager.Data.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Core.Domain.TEntity
    {
        protected readonly TourManagerContext _context;
        
        public Repository(TourManagerContext context)
        {
            this._context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(x =>x != null && x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public int AddWithIdentity(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}