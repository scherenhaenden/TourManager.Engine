using System;

namespace TourManager.Data.Core.Domain
{
    public class Venues: TEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelefonNumber { get; set; }
        public string contactPersons { get; set; }
        public DateTime loadIn { get; set; }
        public DateTime curfView { get; set; }
        
    }
}