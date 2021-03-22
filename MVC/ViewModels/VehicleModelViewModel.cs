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
        public IEnumerable<VehicleMake> VehicleMakeList { get; set; }
        public IEnumerable<VehicleModel> VehicleModelList { get; set; }

        

        //public string VehicleMakeName
        //{

        //    get
        //    {
        //        return context.VehicleMakes.SingleOrDefault(m => m.Id == VehicleModel.MakeId)?.Name;
        //    }
        //}

    }


}
