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
    public class VehicleMakeProfile : Profile
    {
        public VehicleMakeProfile()
        {

            CreateMap<VehicleMake, VehicleMakeViewModel>()
                .ReverseMap();
        }
    }
}
