using LiftOff_Project.Data;
using LiftOff_Project.Models;
using LiftOff_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Controllers
{
    public class HomeController : Controller
    {
        private ServiceDbContext context;

        public HomeController(ServiceDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Service> services = context.Services.Include(s => s.Provider).ToList();

            return View(services);
        }

      
        public IActionResult Detail(int id)
        { 
            Service theService = context.Services
                .Include(s => s.Provider)
                .Single(s => s.Id == id);

            List<ServiceTag> serviceTags = context.ServiceTags
                .Where(st => st.TagId == id)
                .Include(st => st.Tag)
                .ToList();

            ServiceDetailViewModel viewModel = new ServiceDetailViewModel(theService, serviceTags);
            return View(viewModel);
        }
    }
}
