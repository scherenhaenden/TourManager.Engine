using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourManager.Data.Core.Domain
{
    public class Band: TEntity
    {
        public Band()
        {
            Members = new HashSet<Contact>();
            Emails = new HashSet<Email>();
        }
        
        public string Name { get; set; }
        
        public virtual Contact Manager { get; set; }
        
        public string Style { get; set; }
        public virtual ICollection<Contact> Members { get; set; }  
        
        public virtual Address Address { get; set; }
        
        public virtual ICollection<Email> Emails { get; set; }
        
    }
}