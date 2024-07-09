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
    public class PhotoProfile : Profile
    {
        public PhotoProfile()
        {
            CreateMap<PhotoAddDto, CarPhotos>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.Now)).ReverseMap();
        }
    }
}
