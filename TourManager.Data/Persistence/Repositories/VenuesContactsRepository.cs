using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Core.Domain;
using TourManager.Data.Core.Repository;

namespace TourManager.Data.Persistence.Repositories
{
    public class VenuesContactsRepository: Repository<VenuesToContacts>, IVenuesContactsRepository
    {
        private readonly TourManagerContext _context;
        
        

        public VenuesContactsRepository(TourManagerContext context) : base(context)
        {
            _context = context;
            //this.dbSet = context.Set<TourManagerContext>();
        }

        public IQueryable<VenuesToContacts> IncludeMmeL( params Expression<Func<VenuesToContacts, object>>[] includes)
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
            return query as IQueryable<VenuesToContacts>;
            
        }
    }
}