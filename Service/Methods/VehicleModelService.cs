using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Service.PageSortFilter;
using X.PagedList;

namespace Service.Methods
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleContext context;

        public VehicleModelService(VehicleContext context)
        {
            this.context = context;
        }

        //kreiraj metodu Find-vracat ce LIST
        public async Task<IPagedList<VehicleModel>> FindAsync(IFilter filter, ISort sort, IPaging<VehicleModel> paging)
        {
            string SortOrder = sort.SortOrder;
            string CurrentFilter = filter.CurrentFilter;
            string SearchString = filter.SearchString;
            int? pageNumber = filter.pageNumber;



            List<VehicleModel> VehicleModelList = await context.VehicleModels.Include(m => m.VehicleMake).ToListAsync();


            var listFilter = await filter.FilteringAsync(VehicleModelList, SearchString, CurrentFilter);



            var sortModel = await sort.OrderingAsync(listFilter.ToList(), SortOrder);

            var pagedModel = await paging.PagingListAsync(sortModel);

            return pagedModel;
        }
       

        public async Task<VehicleModel> CreateModelAsync(VehicleModel newModel)
        {
            context.VehicleModels.Add(newModel);
            await context.SaveChangesAsync();
            return newModel;
        }

        public async Task<VehicleModel> DeleteModelAsync(int id)
        {
            VehicleModel deletedModel = context.VehicleModels.Find(id);
            context.VehicleModels.Remove(deletedModel);
            await context.SaveChangesAsync();
            //await Task.FromResult(true);
            return deletedModel;
        }
        public async Task<VehicleModel> SelectModelAsync(int id)
        // pisati GetModelAsync --> promijeniti
        {
            return await context.VehicleModels.FindAsync(id);
        }

        public async Task<VehicleModel> UpdateModelAsync(VehicleModel updatedModel)
        {
            var models = context.VehicleModels.Attach(updatedModel);
            models.State = EntityState.Modified;
            await context.SaveChangesAsync();
            return updatedModel;
        }


    }
}
