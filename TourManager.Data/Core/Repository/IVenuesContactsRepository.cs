using System;
using System.Linq;
using System.Linq.Expressions;
using TourManager.Data.Core.Domain;

namespace TourManager.Data.Core.Repository
{
    public interface IVenuesContactsRepository: IRepository<VenuesToContacts>
    {
        IQueryable<VenuesToContacts> IncludeMmeL(params Expression<Func<VenuesToContacts, object>>[] includes);
    }
}