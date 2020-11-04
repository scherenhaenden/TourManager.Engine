using System;
using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Venue: TEntity
    {
        public Venue()
        {
            Addresses = new HashSet<Address>();
            TelefonNumbers = new HashSet<TelefonNumber>();
            Emails = new HashSet<Email>();
        }
        
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<TelefonNumber> TelefonNumbers { get; set; }

        public virtual ICollection<VenuesToContacts> VenuesToContacts { get; set; }
        
        public DateTime LoadIn { get; set; }
        
        public DateTime CurfView { get; set; }
        
        public int MaxCapacity{ get; set; }
        
        public string Notes { get; set; }
        
    }
}