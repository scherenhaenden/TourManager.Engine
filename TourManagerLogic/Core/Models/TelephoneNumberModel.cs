namespace TourManagerLogic.Core.Models
{
    public class TelephoneNumberModel: BaseModel
    {
        public string Number { get; set; }
        public int? ContactId { get; set; }
        
        public int? VenueId { get; set; }
    }
}