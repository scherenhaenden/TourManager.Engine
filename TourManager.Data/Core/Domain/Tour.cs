using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Tour: TEntity
    {
        public Tour()
        {
            TouringDates = new HashSet<TouringDate>();
        }  
        public string NameOfTour { get; set; }
        public virtual ICollection<TouringDate> TouringDates { get; set; }
    }
}