using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Methods
{
    public interface IVehicleModelService
    {
        public VehicleModel UpdateModel(VehicleModel updatedModel);
        public VehicleModel CreateModel(VehicleModel newModel);
        public VehicleModel DeleteModel(int id);
        public VehicleModel SelectModel(int id);

    }
}
