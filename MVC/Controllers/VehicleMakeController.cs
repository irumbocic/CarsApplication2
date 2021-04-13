using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MVC.ViewModels;
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
    public class VehicleMakeController : Controller
    {
        private readonly IVehicleMakeService vehicleMakeService;
        private readonly IMapper mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            this.vehicleMakeService = vehicleMakeService;
            this.mapper = mapper;
        }
        public async Task<IActionResult> IndexAsync(string sortOrder, string currentFilter, string searchString, int? pageNumber, int? page)
        {
            //ZADNJA VERZIJA


            FilterMake filter = new FilterMake();

            SortMake sort = new SortMake();

            Paging<VehicleMake> paging = new Paging<VehicleMake>();

            filter.CurrentFilter = currentFilter;
            filter.SearchString = searchString;
            filter.pageNumber = pageNumber;


            sort.SortOrder = sortOrder;

            paging.page = page;


            ViewData["CurrentSort"] = sort.SortOrder;

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sort.SortOrder) ? "nameDesc" : "";
            ViewData["AbrvSortParam"] = string.IsNullOrEmpty(sort.SortOrder) ? "abrvDesc" : "";
            ViewData["MakeIdSortParam"] = string.IsNullOrEmpty(sort.SortOrder) ? "makeIdDesc" : "";


            var makeList = await vehicleMakeService.FindAsync(filter, sort, paging);

            IEnumerable<VehicleMakeViewModel> viewModelList = mapper.Map<IEnumerable<VehicleMakeViewModel>>(makeList);
            IPagedList<VehicleMakeViewModel> pagedViewModelList = new StaticPagedList<VehicleMakeViewModel>(viewModelList, makeList.GetMetaData());


            return View(pagedViewModelList);

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

            if (selectedMake == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(mapper.Map<VehicleMakeViewModel>(selectedMake));
            }

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
            if (selectedMake == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                return View(selectedMake);

            }
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
            if (selectedMake == null)
            {
                return RedirectToAction("Error", "Home");

            }
            else
            {
                return View(mapper.Map<VehicleMakeViewModel>(selectedMake));

            }
        }


    }
}
