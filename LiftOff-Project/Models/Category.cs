using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Service> Services { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public Category()
        {
        }
    }
}
