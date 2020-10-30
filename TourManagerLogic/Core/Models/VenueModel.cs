using System;
using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class VenueModel: BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<AddressModel> Addresses { get; set; }
        
        public virtual ICollection<EmailModel> Emails { get; set; } = new List<EmailModel>();
        public virtual ICollection<TelefonNumberModel> TelefonNumbers { get; set; } = new List<TelefonNumberModel>();
        
        public virtual ICollection<ContactModel> Contact { get; set; } = new List<ContactModel>();
        public DateTime loadIn { get; set; }
        public DateTime curfView { get; set; }
        
        public int MaxCapacity{ get; set; }
        
        public string Notes { get; set; }
    }
}