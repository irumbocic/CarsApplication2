using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ViewModels;
using ReflectionIT.Mvc.Paging;
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
        private readonly IMapper mapper;

        public VehicleModelController(VehicleContext context, IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.context = context;
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;
        }
        //-AutoMapper
        public  async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewData["AbrvSortParam"] = string.IsNullOrEmpty(sortOrder) ? "abrvDesc" : "";
            ViewData["MakeIdSortParam"] = string.IsNullOrEmpty(sortOrder) ? "makeIdDesc" : "";


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var model = from m in context.VehicleModels
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(m => m.Name.Contains(searchString) || m.Abrv.Contains(searchString)); // ovdje moram dodati i make-name, kad to sredim
            }
            

            switch (sortOrder)
            {
                case "nameDesc":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                case "abrvDesc":
                    model = model.OrderByDescending(m => m.Abrv);
                    break;
                case "makeIdDesc":
                    model = model.OrderByDescending(m => m.MakeId);
                    break;
                default:
                    model = model.OrderBy(m => m.Id);
                    break;
            }

            int pageSize = 10;
            //return View(mapper.Map<IEnumerable<VehicleModelViewModel>>(model));
            return View(await PaginatedList<VehicleModel>.CreateAsync(model.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        
        
        //GET-Create
        public IActionResult Create()
        {
            return View();

        }


        //POST-Create-AutoMapper

        public async Task<IActionResult> CreatePost(VehicleModelViewModel newViewModel) // ovdje ubaci u funkciju veiwModel, onda (red ispod) mapiraj taj vm u model
        {
            var newModel = mapper.Map<VehicleModel>(newViewModel); // ovo ce mapirati object iz VehicleModelViewModel u VehicleModel
            await vehicleModelService.CreateModelAsync(newModel);
            return RedirectToAction("Index");
        }


        //GET-Edit-AutoMapper
        public async Task<IActionResult> Edit(int id)
        {
            var selectedModel = await vehicleModelService.SelectModelAsync(id);
            if (selectedModel == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(mapper.Map<VehicleModelViewModel>(selectedModel)); // tu mi je mapirano iz vehiclemodel u viewModel
            }
        }

        //POST-Edit-AutoMapper
        public async Task<IActionResult> EditPost(VehicleModelViewModel updatedViewModel) // provjeri trebas li uopce bit iu viewmodelu ovdje, ili samo ostavim sve da bude VehicleModel
        {
            var updatedModel = mapper.Map<VehicleModel>(updatedViewModel); // tu mi mapira iz viewModela u vehicleModel
            await vehicleModelService.UpdateModelAsync(updatedModel);
            return RedirectToAction("Index");
        }


        //GET-Delete-AutoMapper
        public async Task<IActionResult> Delete(int id)
        {
            var selectedModel = await vehicleModelService.SelectModelAsync(id);
            if (selectedModel == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                //return View(mapper.Map<VehicleModelViewModel>(selectedModel)); // mapirano je u viewModel - TREBAM LI OVO MAPIRATI UOPCE
                return View(selectedModel);
            }
        }

        //POST-Delete
        public async Task<IActionResult> DeletePost(int id) // moram provjeriti ako sam mapirala u viewmodel, je li mi on onda ovaj id gleda iz viewmodela, gdje to namjestam?
        {

            await vehicleModelService.DeleteModelAsync(id);
            //vehicleModelService.DeleteModel(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var selectedModel = await vehicleModelService.SelectModelAsync(id);
            if (selectedModel == null)
            {
                return RedirectToAction("Error", "Home");

            }
            else
            {
                return View(mapper.Map<VehicleModelViewModel>(selectedModel));

            }
        }

    }
}
