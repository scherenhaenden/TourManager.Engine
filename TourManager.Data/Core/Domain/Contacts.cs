namespace TourManager.Data.Core.Domain
{
    public class Contacts: TEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string TelefonNumber { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
    }
}