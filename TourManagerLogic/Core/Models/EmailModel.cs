namespace TourManagerLogic.Core.Models
{
    public class EmailModel: BaseModel
    {
        public string EmailAddress { get; set; }
        
        public int? ContactId { get; set; }

        public int? VenueId { get; set; }
        
        public int? BandId { get; set; }
    }
}