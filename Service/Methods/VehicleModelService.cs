using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Service.Methods
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleContext context;

        public VehicleModelService(VehicleContext context)
        {
            this.context = context;
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
