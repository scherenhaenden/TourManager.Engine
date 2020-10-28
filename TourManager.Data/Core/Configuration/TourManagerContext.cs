using System.IO;
using Microsoft.EntityFrameworkCore;
using TourManager.Data.Core.Domain;

namespace TourManager.Data.Core.Configuration
{
    public class TourManagerContext: DbContext
    {
        public DbSet<Venues> Venues { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public TourManagerContext (DbContextOptions<TourManagerContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        
    }
}