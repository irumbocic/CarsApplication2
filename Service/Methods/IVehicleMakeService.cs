using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Methods
{
    public interface IVehicleMakeService
    {
        public Task<VehicleMake> UpdateMakeAsync(VehicleMake updatedMake);
        public Task<VehicleMake> CreateMakeAsync(VehicleMake newMake);
        public Task<VehicleMake> DeleteMakeAsync(int id);
        public Task<VehicleMake> SelectMakeAsync(int id);

    }
}
