using LiftOff_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.ViewModels
{
    public class ServiceDetailViewModel
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string CategoryName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TagText { get; set; }

        public ServiceDetailViewModel(Service theService, List<ServiceTag> serviceTags)
        {
            ServiceId = theService.Id;
            Name = theService.Name;
            ProviderName = theService.Provider.Name;
            CategoryName = theService.Category.Name;
            Location = theService.Location.Name + "/n" + theService.Location.Address;
            Description = theService.Description;

            TagText = "";
            for(int i = 0; i < serviceTags.Count; i++)
            {
                TagText += serviceTags[i].Tag.Name;
                if(i < serviceTags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }
    }
}
