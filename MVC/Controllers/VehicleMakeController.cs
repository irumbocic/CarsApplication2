using Microsoft.AspNetCore.Mvc;
using Service.EfStructure;
using Service.Methods;
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
        private readonly IVehicleMakeService vehicleMakeService;

        public VehicleMakeController(VehicleContext context, IVehicleMakeService vehicleMakeService)
        {
            this.context = context;
            this.vehicleMakeService = vehicleMakeService;
        }
        public IActionResult Index()
        {
            IEnumerable<VehicleMake> makeList = context.VehicleMakes;
            return View(makeList);
        }

        //GET-Delete
        public IActionResult Delete(int id)
        {
            var selectedMake = vehicleMakeService.SelectMake(id);
            return View(selectedMake);
        }
        //POST-Delete
        public IActionResult DeletePost(int id)
        {
            vehicleMakeService.DeleteMake(id);
            return RedirectToAction("Index");
        }

        //GET-Edit
        public IActionResult Edit(int id)
        {
            var selectedMake = vehicleMakeService.SelectMake(id);
            return View(selectedMake);
        }
        //POST-Edit
        
        public IActionResult EditPost(VehicleMake updatedMake)
        {
            var selectedMake = vehicleMakeService.UpdateMake(updatedMake);
            return RedirectToAction("Index");
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();

        }
        //POST-Create
       
        public IActionResult CreatePost(VehicleMake newMake)
        {
            var selectedMake = vehicleMakeService.CreateMake(newMake);
            return RedirectToAction("Index");
        }
    }
}
