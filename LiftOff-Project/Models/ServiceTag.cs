using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Models
{
    public class ServiceTag
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public ServiceTag()
        {
        }
    }
}
