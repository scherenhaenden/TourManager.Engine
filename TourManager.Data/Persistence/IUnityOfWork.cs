using System;
using TourManager.Data.Core.Domain;
using TourManager.Data.Core.Repository;

namespace TourManager.Data.Persistence
{
    public interface IUnityOfWork: IDisposable
    {
        IRepository<Contact> Contacts { get; }

        IRepository<Address> Address { get; }

        IRepository<Band> Bands { get; }

        IRepository<TouringDate> TouringDates { get; }

        IRepository<Tour> Tours { get; }

        IRepository<Venue> Venues { get; }
        
        IRepository<Email> Emails { get; }
        
        IRepository<TelephoneNumber> TelephoneNumbers { get; }
        
        IVenuesContactsRepository VenuesToContacts { get; }

        int Complete();
    }
}