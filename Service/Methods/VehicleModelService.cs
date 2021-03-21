using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Service.Methods
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleContext context;

        public VehicleModelService(VehicleContext context)
        {
            this.context = context;
        }

        public VehicleModel CreateModel(VehicleModel newModel)
        {
            context.VehicleModels.Add(newModel);
            context.SaveChanges();
            return newModel;
        }

        public VehicleModel DeleteModel(int id)
        {
            VehicleModel deletedModel = context.VehicleModels.Find(id);
            context.VehicleModels.Remove(deletedModel);
            context.SaveChanges();
            return deletedModel;
        }

        public VehicleModel SelectModel(int id)
        {
            return context.VehicleModels.Find(id);
        }

        public VehicleModel UpdateModel(VehicleModel updatedModel)
        {
            var models  = context.VehicleModels.Attach(updatedModel);
            models.State = EntityState.Modified;
            context.SaveChanges();
            return updatedModel;
        }
    }
}
