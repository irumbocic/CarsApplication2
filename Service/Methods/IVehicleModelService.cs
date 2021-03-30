using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Methods
{
    public interface IVehicleModelService
    {
        public Task<VehicleModel> UpdateModelAsync(VehicleModel updatedModel);
        public Task<VehicleModel> CreateModelAsync(VehicleModel newModel);
        public Task<VehicleModel> DeleteModelAsync(int id);
        public Task<VehicleModel> SelectModelAsync(int id);

    }
}
