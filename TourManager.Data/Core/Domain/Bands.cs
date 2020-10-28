namespace TourManager.Data.Core.Domain
{
    public class Bands: TEntity
    {
        public string Name { get; set; }
        public Contact Manager { get; set; }
        public string Style { get; set; }
        
    }
}