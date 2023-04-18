using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using AutoMapper;
using CarListApp.Api.Data;
using CarListApp.Api.Models.Dealership;
using CarListApp.Api.Models.Car;
using CarListApp.Api.Models.Users;

namespace CarListApp.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Dealership, CreateDealershipDto>().ReverseMap();
            CreateMap<Dealership, GetDealershipDto>().ReverseMap();
            CreateMap<Dealership, DealershipDto>().ReverseMap();
            CreateMap<Dealership, UpdateDealershipDto>().ReverseMap();

            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();

            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
        }
    }
}

