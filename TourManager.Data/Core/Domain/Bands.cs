using System.Collections.Generic;

namespace TourManager.Data.Core.Domain
{
    public class Bands: TEntity
    {
        public Bands()
        {
            Members = new HashSet<Contact>();
            Emails = new HashSet<Emails>();
        }
        
        public string Name { get; set; }
        public virtual Contact Manager { get; set; }
        public string Style { get; set; }
        public virtual ICollection<Contact> Members { get; set; }  
        public virtual Address Address { get; set; }
        
        public virtual ICollection<Emails> Emails { get; set; }
        
    }
}