using System;
using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Venue: TEntity
    {
        public Venue()
        {
            Addresses = new HashSet<Address>();
            TelephoneNumbers = new HashSet<TelephoneNumber>();
            Emails = new HashSet<Email>();
            VenuesToContacts = new HashSet<VenuesToContacts>();
        }
        
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<TelephoneNumber> TelephoneNumbers { get; set; }

        public virtual ICollection<VenuesToContacts> VenuesToContacts { get; set; }
        
        public TimeSpan LoadIn { get; set; }
        
        public TimeSpan CurfView { get; set; }
        
        public int MaxCapacity{ get; set; }
        
        public string Notes { get; set; }
        
    }
}