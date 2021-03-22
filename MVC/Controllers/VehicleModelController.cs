using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;
using Service.EfStructure;
using Service.Methods;
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
        private readonly IVehicleModelService vehicleModelService;

        public VehicleModelController(VehicleContext context, IVehicleModelService vehicleModelService)
        {
            this.context = context;
            this.vehicleModelService = vehicleModelService;
        }

        [Inject]
        public IMapper Mapper { get; set; }
        
        public IActionResult Index()
        {
            var viewModel = new VehicleModelViewModel()
            {
                VehicleMakeList = context.VehicleMakes,
                VehicleModelList = context.VehicleModels
            };
            
            return View(viewModel);
        }
        //GET-Delete
        public IActionResult Delete(int id)
        {
            var selectedModel = vehicleModelService.SelectModel(id);
            return View(selectedModel);
        }
        //POST-Delete
        public IActionResult DeletePost(int id)
        {
            vehicleModelService.DeleteModel(id);
            return RedirectToAction("Index");
        }
        //GET-Edit
        public IActionResult Edit(int id)
        {
            var selectedModel = vehicleModelService.SelectModel(id);
            return View(selectedModel);
        }
        //POST-Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(VehicleModel updatedModel)
        {
            var selectedModel = vehicleModelService.UpdateModel(updatedModel);
            return RedirectToAction("Index");
        }
        //GET-Create
        public IActionResult Create()
        {
            return View();

        }
        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(VehicleModel newModel)
        {
            var selectedModel = vehicleModelService.CreateModel(newModel);
            return RedirectToAction("Index");
        }

    }
}
