using TourManager.Data.Core.Configuration;
using TourManager.Data.Core.Domain;
using TourManager.Data.Core.Repository;
using TourManager.Data.Persistence.Repositories;

namespace TourManager.Data.Persistence
{
    public class UnityOfWork: IUnityOfWork
    {
        private readonly TourManagerContext _tourManagerContext;
        private IUnityOfWork _unityOfWorkImplementation;
        private bool _disposed;        
        //FIXME: Microsoft.EntityFrameworkCore.Proxies
        public UnityOfWork(TourManagerContext tourManagerContext)
        {
            _tourManagerContext = tourManagerContext;
            Contacts = new Repository<Contact>(_tourManagerContext);
            Address = new Repository<Address>(_tourManagerContext);
            Bands = new Repository<Band>(_tourManagerContext);
            TouringDates = new Repository<TouringDate>(_tourManagerContext);
            Tours = new Repository<Tour>(_tourManagerContext);
            Venues = new Repository<Venue>(_tourManagerContext);
            
            Emails = new Repository<Email>(_tourManagerContext);
            TelefonNumbers = new Repository<TelefonNumber>(_tourManagerContext);
            
            VenuesToContacts = new VenuesContactsRepository(_tourManagerContext);
        }

        public void Dispose()
        {
            if (!this._disposed) {
                if (_disposed) {
                    _tourManagerContext.Dispose();
                }
                this._disposed = true;
            }
        }

        public IRepository<Contact> Contacts { get; }
        
        public IRepository<Address> Address { get; }

        public IRepository<Band> Bands { get; }

        public IRepository<TouringDate> TouringDates { get; }

        public IRepository<Tour> Tours { get; }

        public IRepository<Venue> Venues { get; }

        public IRepository<Email> Emails { get; }

        public IRepository<TelefonNumber> TelefonNumbers { get; }
        
        public IVenuesContactsRepository VenuesToContacts { get; }

        public int Complete()
        {
            _tourManagerContext.SaveChanges();
            return 0;
        }
    }
}