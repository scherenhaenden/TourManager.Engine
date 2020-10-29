using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Contact: TEntity
    {
        public Contact()
        {
            Addresses = new HashSet<Address>();
            TelefonNumbers = new HashSet<TelefonNumbers>();
            Emails = new HashSet<Emails>();
            
        }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public virtual ICollection<TelefonNumbers> TelefonNumbers { get; set; }
        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}