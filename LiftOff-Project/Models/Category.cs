using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Models
{
    public class Category
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        //[StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public Category()
        {
        }
    }
}
