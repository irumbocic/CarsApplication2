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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Service.Methods
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleContext context;

        public VehicleModelService(VehicleContext context)
        {
            this.context = context;
        }

        public async Task<IPagedList<VehicleModel>> FindAsync(IFilter filter, ISort sort, IPaging<VehicleModel> paging)
        {
            

            IQueryable<VehicleModel> VehicleModelList = context.VehicleModels.Include(m => m.VehicleMake);


            var listFilter = filter.Filtering(VehicleModelList, (Filter)filter);


            var sortModel = sort.Ordering(listFilter, (Sort)sort);

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
        public async Task<VehicleModel> GetModelAsync(int id)
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

        public async Task<IEnumerable<SelectListItem>> GetListOfMakeNamesAsync()
        {
            List<VehicleMake> VehicleMakeList = await context.VehicleMakes.ToListAsync();

            var items = VehicleMakeList.Select(m => new SelectListItem
            {
                Text = m.Name.ToString(),
                Value = m.Id.ToString()
            });
           
            return items;
        }
    }
}
