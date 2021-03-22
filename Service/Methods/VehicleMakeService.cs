using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Service.Methods
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleContext context;

        public VehicleMakeService(VehicleContext context)
        {
            this.context = context;
        }

        public VehicleMake CreateMake(VehicleMake newMake)
        {
            context.VehicleMakes.Add(newMake);
            context.SaveChanges();
            return newMake;
        }

        public VehicleMake DeleteMake(int id)
        {
            var deleteMake = context.VehicleMakes.Find(id);
            context.Remove(deleteMake);
            context.SaveChanges();
            return deleteMake;
        }

        public VehicleMake SelectMake(int id)
        {
            return context.VehicleMakes.Find(id);

        }

        public VehicleMake UpdateMake(VehicleMake updatedMake)
        {
            var makes = context.VehicleMakes.Attach(updatedMake);
            makes.State = EntityState.Modified;
            context.SaveChanges();
            return updatedMake;
        }
    }
}
