using System.IO;
using Microsoft.EntityFrameworkCore;
using TourManager.Data.Core.Domain;

namespace TourManager.Data.Core.Configuration
{
    public class TourManagerContext: DbContext
    {
        public DbSet<Venues> Venues { get; set; }
        public DbSet<Address> Address { get; set; }
        
        public DbSet<Bands> Bands { get; set; }
        
        public DbSet<Contact> Contacts { get; set; }
        
        public DbSet<TouringDates> TouringDates { get; set; }
        
        public DbSet<Tours> Tours { get; set; }
        public TourManagerContext (DbContextOptions<TourManagerContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        
    }
}