using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Core.Repository;

namespace TourManager.Data.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Core.Domain.TEntity
    {
        protected readonly TourManagerContext _context;
        protected DbSet<TEntity> _dbSet;
        private IRepository<TEntity> _repositoryImplementation;

        public Repository(TourManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(x =>x != null && x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Get(int numberOfObjectsPerPage = 10, int pageNumber = 1)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            
            if (numberOfObjectsPerPage < 1)
            {
                numberOfObjectsPerPage = 10;
            }

            var all2 = _context.Set<TEntity>();
            
            
            var all3 
                = 
                all2.Skip(numberOfObjectsPerPage * (pageNumber-1))
                    .Take(numberOfObjectsPerPage).ToList();
            return all3;
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
            entity.Inserted = DateTime.Now;
            entity.LastUpdate = DateTime.Now;
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
            entity.LastUpdate = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
        }

        public void Remove(TEntity entity)
        {
            
            var h = _context.Entry(entity).Properties.ToList();
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        public IQueryable<TEntity> IncludEntities( params Expression<Func<TEntity, object>>[] includes)
        {
            
            IIncludableQueryable<TEntity, object> query = null;

            if(includes.Length > 0)
            {
                query = _dbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = _dbSet.Include(includes[queryIndex]);
            }

            if (query == null)
            {
                return _dbSet;
            }
            return query as IQueryable<TEntity>;
            
        }

        public IEnumerable<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, TResult>> selector) where TEntity : Core.Domain.TEntity
        {
            return _context.Set<TEntity>().Select(selector);    
        }


        /*public IQueryable<TEntity> IncludeMmeL<TEntity>( params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            
            IIncludableQueryable<TEntity, object> query = null;

            if(includes.Length > 0)
            {
                query = _dbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            if (query == null)
            {
                return _dbSet;
            }


            query == null ? _dbSet : (IQueryable<TEntity>)query;

            return query == null ? _dbSet : (IQueryable<TEntity>)query;
            
        }*/
        
        
       /* public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter,
            int skip = 0,
            int take = int.MaxValue,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IList<string> incudes = null)
        {
            var _resetSet = filter != null ? _context.Set<Core.Domain.TEntity>().AsNoTracking().Where(filter).AsQueryable() : _context.Set<Core.Domain.TEntity>().AsNoTracking().AsQueryable();

            if (incudes != null)
            {
                foreach (var incude in incudes)
                {
                    _resetSet = _resetSet.Include(incude);
                }
            }
            if (orderBy != null)
            {
                _resetSet = orderBy(_resetSet).AsQueryable();
            }
            _resetSet = skip == 0 ? _resetSet.Take(take) : _resetSet.Skip(skip).Take(take);

            return _resetSet.AsQueryable();
        }*/

       /* public virtual IQueryable<TEntity> GetAllLazyLoad(IQueryable<TEntity> query,Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children)
        {
            
            _context.Set<TEntity>().ToList().ForEach(x=>query.Include(children).Load());


            children.ToList().ForEach(x=>query.Include(x).Load());
            return query;
        }
        public IQueryable<TEntity> IncludeMultiple<TEntity>(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, 
                    (current, include) => current.Include(include));
            }

            return query;
        }*/

        /*public IQueryable<TEntity> IncludeMultiple<TEntity>(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, 
                    (current, include) => current .Include(include));
            }

            return query;
        }*/
    }

    public static class RepositoryExtension
    {
      /*  public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, 
                    (current, include) => current.Include(include));
            }

            return query;
        }*/
    }
}