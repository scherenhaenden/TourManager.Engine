using System.Collections.Generic;
using TourManager.Data.Core.Domain;

namespace TourManagerLogic.Core.Models
{
    public class TourModel: BaseModel
    {
        public string NameOfTour { get; set; }
        public virtual ICollection<TouringDatesModel> TouringDates { get; set; }
        public virtual ICollection<BandModel> Bands { get; set; }
    }
}