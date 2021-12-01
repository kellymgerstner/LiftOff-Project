using LiftOff_Project.Data;
using LiftOff_Project.Models;
using LiftOff_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Controllers
{
    public class SearchController : Controller
    {
        private ServiceDbContext context;

        public SearchController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Service> services;
            List<ServiceDetailViewModel> displayServices = new List<ServiceDetailViewModel>();

            if (string.IsNullOrEmpty(searchTerm))
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
            }
            else
            {
                if(searchType == "provider")
                {
                    services = context.Services
                        .Include(s => s.Provider)
                        .Where(s => s.Provider.Name == searchTerm)
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
                else if (searchType == "category")
                {
                    services = context.Services
                        .Include(s => s.Category)
                        .Where(s => s.Category.ToString() == searchTerm)
                        .ToList();

                    foreach (Service service in services)
                    {
                        List<ServiceTag> serviceTags = context.ServiceTags
                            .Where(st => st.ServiceId == service.Id)
                            .Include(st => st.Tag)
                            .ToList();

                        ServiceDetailViewModel newDisplayService = new ServiceDetailViewModel(service, serviceTags);
                        displayServices.Add(newDisplayService);
                    }
                }
                else if(searchType == "location")
                {
                    services = context.Services
                        .Include(s => s.Location)
                        .Where(s => s.Location.ToString() == searchTerm)
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
            }
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Jobs with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;
            ViewBag.services = displayServices;

            return View("Index");
        }
    }
}
