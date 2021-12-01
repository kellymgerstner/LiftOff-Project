using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<ServiceTag> ServiceTags { get; set; }

        public Service()
        {
        }

        public Service(string name)
        {
            Name = name;
        }
        
    }
}
