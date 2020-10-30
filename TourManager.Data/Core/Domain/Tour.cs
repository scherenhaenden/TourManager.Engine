using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Tour: TEntity
    {
        public Tour()
        {
            TouringDates = new HashSet<TouringDate>();
            Bands = new HashSet<Band>();
        }  
        public string NameOfTour { get; set; }
        public virtual ICollection<TouringDate> TouringDates { get; set; }
        public virtual ICollection<Band> Bands { get; set; }
    }
}