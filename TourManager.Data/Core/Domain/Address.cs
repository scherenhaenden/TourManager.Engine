namespace TourManager.Data.Core.Domain
{
    public class Address: TEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNameOrNumber { get; set; }
        public string PostalZip { get; set; }
        public string ExtranInfo { get; set; }
        public int? ContactId { get; set; }
        public int? VenueId { get; set; }
    }
}