using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TourManagerLogic.Core.Models
{
    public class ContactModel: BaseModel
    {
        public string FirstName { get; set; } 
        
        public string LastName { get; set; }
        
        public  int? VenueId { get; set; }

        public virtual ICollection<TelephoneNumberModel> TelephoneNumbers { get; set; } = new Collection<TelephoneNumberModel>();
        
        public virtual ICollection<EmailModel> Emails { get; set; } = new Collection<EmailModel>();
        
        public virtual ICollection<AddressModel> Addresses { get; set; } = new Collection<AddressModel>();
        
        public virtual ICollection<VenuesToContactsModel> VenuesToContacts { get; set; }= new List<VenuesToContactsModel>();
    }
}