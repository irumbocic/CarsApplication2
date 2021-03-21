using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly VehicleContext context;

        public VehicleModelController(VehicleContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            IEnumerable<VehicleModel> modelList = context.VehicleModels;
            return View(modelList);
        }

        
    }
}
