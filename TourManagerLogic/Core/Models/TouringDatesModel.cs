using System;
using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class TouringDatesModel: BaseModel
    {
        public DateTime DateOfTour  { get; set; }
        public virtual VenueModel Venue { get; set; }
        public virtual BandModel Band { get; set; }
    }
}