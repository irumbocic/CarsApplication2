using AutoMapper;
using MVC.ViewModels;
using Service.EfStructure;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class VehicleModelProfile : Profile
    {
        //private readonly VehicleContext context;
        // Izmjeniti kad napravim update!
        public VehicleModelProfile()
        {
            //CreateMap<VehicleModel, VehicleModelViewModel>();
                
            //CreateMap<VehicleModelViewModel, VehicleModel>();
            //this.context = context;

            CreateMap<VehicleModel, VehicleModelViewModel>()
                .ReverseMap();
        }
    }
}
