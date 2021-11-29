using LiftOff_Project.Models;
using Microsoft.AspNetCore.Mvc;
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
        private Dbcontext context;

        public HomeController(DbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Service> services = context.Services.Include(s => s.Provider).ToList();

            return View(services);
        }

      
        public IActionResult Detail(int id)
       
            Service theService = context.Services
                .Include(s => s.Provider)
                .Single(s => s.Id == id);

            ServiceDetailViewModel viewModel = new ServiceDetailViewModel(theService);
            return View(viewModel);
        }
    }
}
