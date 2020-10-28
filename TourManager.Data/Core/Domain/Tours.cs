using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Tours: TEntity
    {
        public Tours()
        {
            TouringDates = new HashSet<TouringDates>();
        }  
        public string NameOfTour { get; set; }
        public virtual ICollection<TouringDates> TouringDates { get; set; }
    }
}