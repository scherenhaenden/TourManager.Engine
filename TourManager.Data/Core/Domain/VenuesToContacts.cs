namespace TourManager.Data.Core.Domain
{
    public class VenuesToContacts: TEntity
    {
        public int VenueId { get; set; }
        public int ContactId { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual Contact Contact { get; set; }
    }
}