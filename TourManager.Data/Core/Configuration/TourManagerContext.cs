using Microsoft.EntityFrameworkCore;
using TourManager.Data.Core.Domain;

namespace TourManager.Data.Core.Configuration
{
    public class TourManagerContext: DbContext
    {
        
        public DbSet<Address> Address { get; set; }
        
        public DbSet<Band> Bands { get; set; }
        
        public DbSet<Contact> Contacts { get; set; }
        
        public DbSet<Email> Emails { get; set; }
        
        public DbSet<TelefonNumber> TelefonNumbers { get; set; }

        public DbSet<Tour> Tours { get; set; }
        
        public DbSet<TouringDate> TouringDates { get; set; }
        
        public DbSet<Venue> Venues { get; set; }
        public TourManagerContext (DbContextOptions<TourManagerContext> options) : base(options)
        {
            
            Database.Migrate();
        }
        
        
    }
}