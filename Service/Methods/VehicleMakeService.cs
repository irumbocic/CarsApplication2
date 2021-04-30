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
           
            IQueryable<VehicleMake> VehicleMakeList = context.VehicleMakes;


            var listFilter = filter.Filtering(VehicleMakeList, (FilterMake)filter);

            var sortMake = sort.Ordering(listFilter, (SortMake)sort);

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

        public async Task<VehicleMake> GetMakeAsync(int id)
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
