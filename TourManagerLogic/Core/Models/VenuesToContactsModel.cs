namespace TourManagerLogic.Core.Models
{
    public class VenuesToContactsModel: BaseModel
    {
        public int VenueId { get; set; }
        public int ContactId { get; set; }
        public virtual VenueModel Venue { get; set; }
        public virtual ContactModel Contact { get; set; }
    }
}