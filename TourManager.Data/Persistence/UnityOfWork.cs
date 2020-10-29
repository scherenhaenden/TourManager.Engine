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

        public UnityOfWork(TourManagerContext tourManagerContext)
        {
            _tourManagerContext = tourManagerContext;
            Contacts = new Repository<Contact>(_tourManagerContext);
            Address = new Repository<Address>(_tourManagerContext);
            Bands = new Repository<Bands>(_tourManagerContext);
            TouringDates = new Repository<TouringDates>(_tourManagerContext);
            Tours = new Repository<Tours>(_tourManagerContext);
            Venues = new Repository<Venues>(_tourManagerContext);
            
            Emails = new Repository<Emails>(_tourManagerContext);
            TelefonNumbers = new Repository<TelefonNumbers>(_tourManagerContext);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IRepository<Contact> Contacts { get; }
        public IRepository<Address> Address { get; }

        public IRepository<Bands> Bands { get; }

        public IRepository<TouringDates> TouringDates { get; }

        public IRepository<Tours> Tours { get; }

        public IRepository<Venues> Venues { get; }
        public IRepository<Emails> Emails { get; }
        public IRepository<TelefonNumbers> TelefonNumbers { get; }

        public int Complete()
        {
            _tourManagerContext.SaveChanges();
            return 0;
        }
    }
}