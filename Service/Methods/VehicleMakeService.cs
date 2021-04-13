using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using X.PagedList;
using Service.PageSortFilter;

namespace Service.Methods
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleContext context;

        public VehicleMakeService(VehicleContext context)
        {
            this.context = context;
        }


        //public async Task<IPagedList<VehicleMake>> FindAsync(IFilter filter, ISort sort, IPaging<VehicleMake> paging)
        //{
            //string SortOrder = sort.SortOrder;
            //string CurrentFilter = filter.CurrentFilter;
            //string SearchString = filter.SearchString;
            //int? pageNumber = filter.pageNumber;



            //List<VehicleMake> VehicleMakelList = await context.VehicleMakes.ToListAsync();


            //var listFilter = filter.Filtering(VehicleMakelList, SearchString, CurrentFilter);



            //var sortModel = await sort.Ordering(listFilter.Result.ToList(), SortOrder);

            //var pagedModel = paging.PagingList(sortModel);

            //return pagedModel;
        //}

        public async Task<VehicleMake> CreateMakeAsync(VehicleMake newMake)
        {
            context.VehicleMakes.Add(newMake);
            await context.SaveChangesAsync();
            return newMake;
        }

        public async Task<VehicleMake> DeleteMakeAsync(int id)
        {
            var deleteMake = context.VehicleMakes.Find(id);
            context.Remove(deleteMake);
            await context.SaveChangesAsync();
            return deleteMake;
        }

        public async Task<VehicleMake> SelectMakeAsync(int id)
        {
            return await context.VehicleMakes.FindAsync(id);
        }

        public async Task<VehicleMake> UpdateMakeAsync(VehicleMake updatedMake)
        {
            var makes = context.VehicleMakes.Attach(updatedMake);
            makes.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return updatedMake;
        }

    }
}
