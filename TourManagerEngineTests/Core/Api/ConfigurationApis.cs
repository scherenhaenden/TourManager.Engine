using Microsoft.EntityFrameworkCore;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;

namespace TourManagerEngineTests.Core.Api
{
    public class ConfigurationApis
    {
        public IUnityOfWork GetUnityConfigurated()
        {
            DbContextOptionsBuilder<TourManagerContext> options = new DbContextOptionsBuilder<TourManagerContext>();
            options.UseLazyLoadingProxies();
            //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
            DbContextOptions options2 = new DbContextOptions<TourManagerContext>();
            options.UseSqlite($"Data Source=./TourManager.db");
            TourManagerContext tourManagerContext = new TourManagerContext(options.Options);
            return new UnityOfWork(tourManagerContext);
        
        }
    }
}