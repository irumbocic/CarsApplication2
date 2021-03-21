using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Methods
{
    public interface IVehicleMakeService
    {
        public VehicleMake UpdateMake(VehicleMake updatedMake);
        public VehicleMake CreateMake(VehicleMake newMake);
        public VehicleMake DeleteMake(int id);
        public VehicleMake SelectMake(int id);

    }
}
