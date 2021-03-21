using Microsoft.AspNetCore.Mvc;
using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly VehicleContext context;

        public VehicleMakeController(VehicleContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<VehicleMake> makeList = context.VehicleMakes;
            return View(makeList);
        }

        
    }
}
