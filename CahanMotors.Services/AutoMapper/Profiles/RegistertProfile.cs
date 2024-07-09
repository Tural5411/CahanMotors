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
    public class RegistertProfile:Profile
    {
        public RegistertProfile()
        {
            CreateMap<Registers, RegisterAddDto>();
            CreateMap<RegisterAddDto, Registers>();

            CreateMap<Registers, RegisterUpdateDto>();
            CreateMap<RegisterUpdateDto, Registers>();
        }
    }
}
