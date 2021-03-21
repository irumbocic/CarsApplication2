using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class VehicleModelViewModel
    {
        private readonly VehicleContext context;

        public VehicleModelViewModel(VehicleContext context)
        {
            this.context = context;
        }


        //Ne ide ovako, probaj nesto drugo

        public VehicleModel VehicleModel { get; set; }
        public string VehicleMakeName
        {

            get
            {
                return context.VehicleMakes.SingleOrDefault(m => m.Id == VehicleModel.MakeId)?.Name;
            }
        }

    }
}
