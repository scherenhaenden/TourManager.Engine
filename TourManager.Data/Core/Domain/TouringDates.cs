using System;
using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class TouringDates: TEntity
    {
        public DateTime DateOfTour  { get; set; }
        public virtual ICollection<Venues> Venues { get; set; }
    }
}