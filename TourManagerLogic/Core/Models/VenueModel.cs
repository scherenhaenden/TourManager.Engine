using System;
using System.Collections.Generic;

namespace TourManagerLogic.Core.Models
{
    public class VenueModel: BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<AddressModel> Addresses { get; set; }= new List<AddressModel>();
        public virtual ICollection<EmailModel> Emails { get; set; } = new List<EmailModel>();
        public virtual ICollection<TelefonNumberModel> TelefonNumbers { get; set; } = new List<TelefonNumberModel>();
        public virtual ICollection<VenuesToContactsModel> VenuesToContacts { get; set; }= new List<VenuesToContactsModel>();
        public DateTime LoadIn { get; set; }
        public DateTime CurfView { get; set; }
        
        public int MaxCapacity{ get; set; }
        
        public string Notes { get; set; }
    }
}