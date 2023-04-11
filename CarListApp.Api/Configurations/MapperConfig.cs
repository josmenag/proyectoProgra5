using System;
using AutoMapper;
using CarListApp.Api.Data;
using CarListApp.Api.Models.Cars;
using CarListApp.Api.Models.Dealership;
using CarListApp.Api.Models.Users;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

