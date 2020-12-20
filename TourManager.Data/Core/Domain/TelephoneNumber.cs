namespace TourManager.Data.Core.Domain
{
    public class TelephoneNumber: TEntity
    {
        public string Number { get; set; }
        
        public int? ContactId { get; set; }
        
        public int? VenueId { get; set; }
    }
}