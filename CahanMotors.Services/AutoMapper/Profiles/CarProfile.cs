using AutoMapper;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Services.AutoMapper.Profiles
{
    public class CarProfile:Profile
    {
        public CarProfile()
        {
            CreateMap<CarAddDto, Car>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<CarUpdateDto, Car>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Car, CarUpdateDto>();
        }
    }
}
