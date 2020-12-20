using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Contact: TEntity
    {
        public Contact()
        {
            Addresses = new HashSet<Address>();
            TelefonNumbers = new HashSet<TelefonNumber>();
            Emails = new HashSet<Email>();
            VenuesToContacts = new HashSet<VenuesToContacts>();
            
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        /*[ForeignKey("BandId")]
        public  int? BandId { get; set; }*/
        
        public  int? VenueId { get; set; }
        public virtual ICollection<TelefonNumber> TelefonNumbers { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        
        public virtual ICollection<VenuesToContacts> VenuesToContacts { get; set; }
    }
}