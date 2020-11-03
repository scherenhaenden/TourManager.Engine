namespace TourManagerLogic.Core.Models
{
    public class TelefonNumberModel: BaseModel
    {
        public string Number { get; set; }
        public int? ContactId { get; set; }
        
        public int? VenueId { get; set; }
    }
}