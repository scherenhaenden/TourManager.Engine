using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TourManagerLogic.Core.Models
{
    public class ContactsModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } 
        
        public string LastName { get; set; }

        public virtual ICollection<TelefonNumberModel> TelefonNumbers { get; set; } = new Collection<TelefonNumberModel>();
        
        public virtual ICollection<EmailModel> Emails { get; set; } = new Collection<EmailModel>();
        
        public virtual ICollection<AddressModel> Addresses { get; set; } = new Collection<AddressModel>();
    }
}