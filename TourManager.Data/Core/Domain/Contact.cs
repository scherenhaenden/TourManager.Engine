using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Contact: TEntity
    {
        public Contact()
        {
            this.Address = new HashSet<Address>();
        }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string TelefonNumber { get; set; }
        
        public string Email { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}