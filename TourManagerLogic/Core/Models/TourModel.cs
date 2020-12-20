using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class TourModel: BaseModel
    {
        public string NameOfTour { get; set; }
        public virtual ICollection<TouringDatesModel> TouringDates { get; set; }
        public virtual ICollection<BandModel> Bands { get; set; }
    }
}