using System;
using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Venues: TEntity
    {
        public Venues()
        {
            Addresses = new HashSet<Address>();
            TelefonNumbers = new HashSet<TelefonNumbers>();
            Emails = new HashSet<Emails>();
        }
        
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        
        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<TelefonNumbers> TelefonNumbers { get; set; }
        
        public virtual ICollection<Contact> Contact { get; set; }
        public DateTime loadIn { get; set; }
        public DateTime curfView { get; set; }
        
    }
}