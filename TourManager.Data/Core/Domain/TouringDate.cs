using System;

namespace TourManager.Data.Core.Domain
{
    public class TouringDate: TEntity
    {
        public DateTime DateOfTour  { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual Band Band { get; set; }
    }
}