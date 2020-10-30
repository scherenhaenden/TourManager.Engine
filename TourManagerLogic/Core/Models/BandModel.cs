using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class BandModel
    {
        public string Name { get; set; }
        public virtual ContactModel Manager { get; set; }
        public string Style { get; set; }
        public virtual ICollection<ContactModel> Members { get; set; }  
        public virtual AddressModel Address { get; set; }
        
        public virtual ICollection<EmailModel> Emails { get; set; }
    }
}