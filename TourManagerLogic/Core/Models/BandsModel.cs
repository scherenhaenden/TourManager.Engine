using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class BandsModel
    {
        public string Name { get; set; }
        public virtual ContactsModel Manager { get; set; }
        public string Style { get; set; }
        public virtual ICollection<ContactsModel> Members { get; set; }  
        public virtual AddressModel Address { get; set; }
        
        public virtual ICollection<EmailModel> Emails { get; set; }
    }
}