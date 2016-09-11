using AutoMapper;
using iAsset.App.Domain.Entity;
using iAsset.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iAsset.App.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Flight, FlightViewModel>();
            CreateMap<Gate, GateViewModel>();

            CreateMap<FlightViewModel, Flight >();
        }
    }
}