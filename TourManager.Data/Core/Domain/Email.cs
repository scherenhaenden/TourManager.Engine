namespace TourManager.Data.Core.Domain
{
    public class Email: TEntity
    {
        public string EmailAddress { get; set; }
        public int? ContactId { get; set; }
        
        public int? VenueId { get; set; }
        
        public int? BandId { get; set; }
    }
}