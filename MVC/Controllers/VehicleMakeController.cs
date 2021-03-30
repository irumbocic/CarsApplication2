using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class VehicleMakeController : Controller
    {
        private readonly VehicleContext context;
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleMakeController(VehicleContext context, IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.context = context;
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = sortOrder;

            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["AbrvSortParam"] = String.IsNullOrEmpty(sortOrder) ? "abrvDesc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var makeList = from m in context.VehicleMakes
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                makeList = makeList.Where(m => m.Abrv.Contains(searchString) || m.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nameDesc":
                    makeList = makeList.OrderByDescending(m => m.Name);
                    break;
                case "abrvDesc":
                    makeList = makeList.OrderByDescending(m => m.Abrv);
                    break;
                default:
                    makeList = makeList.OrderBy(m => m.Id);
                    break;
            }

            int pageSize = 10;
            //return View(mapper.Map<IEnumerable<VehicleMakeViewModel>>(makeList));

            var makeListMapped = mapper.Map<IEnumerable<VehicleMakeViewModel>>(makeList);

            return View(await PaginatedList<VehicleMake>.CreateAsync(makeList.AsNoTracking(), pageNumber ?? 1, pageSize));
        }



        //GET-Create
        public IActionResult Create()
        {
            return View();

        }
        //POST-Create
       
        public async Task<IActionResult> CreatePost(VehicleMakeViewModel newViewModel)
        {
            var newMake = mapper.Map<VehicleMake>(newViewModel);
            await vehicleMakeService.CreateMakeAsync(newMake);
            return RedirectToAction("Index");
        }


        //GET-Edit
        public async Task<IActionResult> Edit(int id)
        {
            var selectedMake = await vehicleMakeService.SelectMakeAsync(id);
            return View(mapper.Map<VehicleMakeViewModel>(selectedMake));
        }
        //POST-Edit

        public async Task<IActionResult> EditPost(VehicleMakeViewModel updatedViewModel)
        {
            var updatedMake = mapper.Map<VehicleMake>(updatedViewModel);
            await vehicleMakeService.UpdateMakeAsync(updatedMake);
            return RedirectToAction("Index");
        }


        //GET-Delete
        public async Task<IActionResult> Delete(int id)
        {
            var selectedMake = await vehicleMakeService.SelectMakeAsync(id);
            return View(selectedMake);
        }
        //POST-Delete
        public async Task<IActionResult> DeletePost(int id)
        {
            await vehicleMakeService.DeleteMakeAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var selectedMake = await vehicleMakeService.SelectMakeAsync(id);
            return View(mapper.Map<VehicleMakeViewModel>(selectedMake));
        }


    }
}
