using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using X.PagedList;
using Service.PageSortFilter;
using System.Linq;

namespace Service.Methods
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleContext context;

        public VehicleMakeService(VehicleContext context)
        {
            this.context = context;
        }


        public async Task<IPagedList<VehicleMake>> FindAsync(IFilterMake filter, ISortMake sort, IPaging<VehicleMake> paging)
        {
            string SortOrder = sort.SortOrder;
            string CurrentFilter = filter.CurrentFilter;
            string SearchString = filter.SearchString;
            int? pageNumber = filter.pageNumber;



            List<VehicleMake> VehicleMakeList = await context.VehicleMakes.ToListAsync();


            var listFilter = await filter.FilteringAsync(VehicleMakeList, SearchString, CurrentFilter);



            var sortMake = await sort.OrderingAsync(listFilter.ToList(), SortOrder);

            var pagedMake = await paging.PagingListAsync(sortMake);

            return pagedMake;
        }

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
