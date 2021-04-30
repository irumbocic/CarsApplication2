using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.ViewModels;
using ReflectionIT.Mvc.Paging;
using Service;
using Service.EfStructure;
using Service.Methods;
using Service.Models;
using Service.PageSortFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MVC.Controllers
{

    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService vehicleModelService;
        private readonly IMapper mapper;



        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this.vehicleModelService = vehicleModelService;
            this.mapper = mapper;

        }
        public async Task<IActionResult> IndexAsync(string sortOrder, string currentFilter, string searchString, int? page) 
        {

            Filter filter = new Filter();

            Sort sort = new Sort();

            Paging<VehicleModel> paging = new Paging<VehicleModel>();

            filter.CurrentFilter = currentFilter;
            filter.SearchString = searchString;
            sort.SortOrder = sortOrder;
            paging.page = page;


            TempData["CurrentSort"] = sort.SortOrder;

            TempData["NameSortParam"] = string.IsNullOrEmpty(sort.SortOrder) ? "nameDesc" : "";
            TempData["AbrvSortParam"] = string.IsNullOrEmpty(sort.SortOrder) ? "abrvDesc" : "";
            TempData["MakeIdSortParam"] = string.IsNullOrEmpty(sort.SortOrder) ? "makeIdDesc" : "";


            var modelList = await vehicleModelService.FindAsync(filter, sort, paging);

            var viewModelList = mapper.Map<IEnumerable<VehicleModelViewModel>>(modelList);

            IPagedList<VehicleModelViewModel> pagedViewModelList = new StaticPagedList<VehicleModelViewModel>(viewModelList, modelList.GetMetaData());

            TempData["SearchString"] = filter.SearchString;

            return View(pagedViewModelList);

        }

        //GET-Create
        public async Task<IActionResult> Create()
        {

            var makeNameList = await vehicleModelService.GetListOfMakeNamesAsync();

            IEnumerable<SelectListItem> viewMakeNameList = mapper.Map<IEnumerable<SelectListItem>>(makeNameList);

            ViewBag.viewMakeNameList = viewMakeNameList;

            return View();

        }

        //POST-Create
        public async Task<IActionResult> CreatePost(VehicleModelViewModel newViewModel) // ovdje ubaci u funkciju veiwModel, onda (red ispod) mapiraj taj vm u model
        {
            if (ModelState.IsValid)
            {
                var newModel = mapper.Map<VehicleModel>(newViewModel); // ovo ce mapirati object iz VehicleModelViewModel u VehicleModel
                await vehicleModelService.CreateModelAsync(newModel);
                return RedirectToAction("Index");
            }

            return View("Create", newViewModel);
        }


        //GET-Edit
        public async Task<IActionResult> Edit(int id)
        {
            var selectedModel = await vehicleModelService.GetModelAsync(id);
            if (selectedModel == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {

                var makeNameList = await vehicleModelService.GetListOfMakeNamesAsync();

                IEnumerable<SelectListItem> viewMakeNameList = mapper.Map<IEnumerable<SelectListItem>>(makeNameList);

               
                ViewBag.viewMakeNameList = viewMakeNameList;

                return View(mapper.Map<VehicleModelViewModel>(selectedModel)); // tu mi je mapirano iz vehiclemodel u viewModel
            }

           

        }

        //POST-Edit
        public async Task<IActionResult> EditPost(VehicleModelViewModel updatedViewModel) // provjeri trebas li uopce bit iu viewmodelu ovdje, ili samo ostavim sve da bude VehicleModel
        {


            if (ModelState.IsValid)
            {
                var updatedModel = mapper.Map<VehicleModel>(updatedViewModel); // tu mi mapira iz viewModela u vehicleModel
                await vehicleModelService.UpdateModelAsync(updatedModel);
                return RedirectToAction("Index");
            }
            return View("Edit", updatedViewModel);

        }


        //GET-Delete
        public async Task<IActionResult> Delete(int id)
        {
            var selectedModel = await vehicleModelService.GetModelAsync(id);
            if (selectedModel == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(mapper.Map<VehicleModelViewModel>(selectedModel)); // mapirano je u viewModel 

                //return View(selectedModel);
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
            var selectedModel = await vehicleModelService.GetModelAsync(id);
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
