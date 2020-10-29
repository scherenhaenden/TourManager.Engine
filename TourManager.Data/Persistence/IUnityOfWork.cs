using System;
using TourManager.Data.Core.Domain;
using TourManager.Data.Core.Repository;

namespace TourManager.Data.Persistence
{
    public interface IUnityOfWork: IDisposable
    {
        IRepository<Contact> Contacts { get; }
        IRepository<Address> Address { get; }
        IRepository<Bands> Bands { get; }
        IRepository<TouringDates> TouringDates { get; }
        IRepository<Tours> Tours { get; }
        IRepository<Venues> Venues { get; }
        
        IRepository<Emails> Emails { get; }
        
        IRepository<TelefonNumbers> TelefonNumbers { get; }

        int Complete();
    }
}