using System;

namespace TourManager.Data.Core.Domain
{
    public class TouringDates: TEntity
    {
        public DateTime DateOfTour  { get; set; }
        public Venues venue { get; set; }
    }
}