using AutoMapper;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using System;

namespace CahanMotors.Services.AutoMapper.Profiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderAddDto, Slider>().ForMember(dest=>dest.CreatedDate,opt=>opt.MapFrom(x=>DateTime.Now));
            CreateMap<SliderUpdateDto, Slider>().ForMember(dest=>dest.ModifiedDate,opt=>opt.MapFrom(x=>DateTime.Now));
            CreateMap<Slider, SliderUpdateDto>();
        }
    }
}
