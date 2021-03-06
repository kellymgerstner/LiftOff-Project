using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }

        public Provider()
        {
        }

        public Provider(string name, Location location)
        {
            Name = name;
            Location = location;
        }
    }
}
