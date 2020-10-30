using System;
using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class TouringDatesModel: BaseModel
    {
        public DateTime DateOfTour  { get; set; }
        public virtual ICollection<VenueModel> Venues { get; set; }
    }
}