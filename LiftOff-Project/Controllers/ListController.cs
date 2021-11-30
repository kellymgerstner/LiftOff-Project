using LiftOff_Project.Models;
using LiftOff_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All" },
            {"provider", "Provider" },
            {"service", "Service"}
        };

        internal static List<string> TableChoices = new List<string>()
        {
            "provider",
            "service"
        };

        private ServiceDbContext context;

        public ListController(ServiceDbContext dbcontext)
        {
            context = dbcontext;
        }
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.providers = context.Providers.ToList();
            ViewBag.services = context.Services.ToList();
            return View();
        }

        public IActionResult Services(string column, string value)
        {
            List<Service> services = new List<Service>();
            List<ServiceDetailViewModel> displayServices = new List<ServiceDetailViewModel>();

            if (column.ToLower().Equals("all"))
            {
                services = context.Services
                    .Include(s => s.Provider)
                    .ToList();

                foreach (var service in services)
                {
                    List<ServiceTag> serviceTags = context.ServiceTags
                        .Where(st => st.ServiceId == service.Id)
                        .Include(st => st.Tag)
                        .ToList();

                    ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                    displayServices.Add(newDisplayService);
                }
                ViewBag.title = "All Services";
            }
            else
            {
                if(column == "provider")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Name == value)
                        .ToList();

                    foreach(Service service in services)
                    {
                        List<ServiceTag> serviceTags = context.ServiceTags
                            .Where(st => st.ServiceId == service.Id)
                            .Include(st => st.Tag)
                            .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                        displayServices.Add(newDisplayService);
                    }
                }
                else if(column == "tag")
                {
                    List<ServiceTag> serviceTags = context.ServiceTags
                        .Where(s => s.Tag.Name == value)
                        .Include(s => s.Service)
                        .ToList();

                    foreach (var service in serviceTags)
                    {
                        Service foundService = context.Services
                            .Include(s => s.Provider)
                            .SIngle(s => s.Id == service.ServiceId);

                        List<ServiceTag> displayTags = context.ServiceTags
                            .Where(st => st.ServiceId == foundService.Id)
                            .Include(st => st.Tag)
                            .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(foundService, displayTags);
                        displayServices.Add(newDisplayService);
                    }
                }
                ViewBag.title = "Services with " + ColumnChoices[column] + ": " + value;
            }
            ViewBag.services = displayServices;

            return View();
        }
    }
}
