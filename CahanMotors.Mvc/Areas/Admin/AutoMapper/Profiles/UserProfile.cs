using AutoMapper;
using CahanMotors.Entities.ComplexTypes;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using CahanMotors.Mvc.Areas.Admin.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile(/*IImageHelper imageHelper*/)
        {
            CreateMap<UserAddDto, User>();
            //    .ForMember(dest=>dest.Picture,opt=>opt
            //.MapFrom(x=>imageHelper.UploadImage(x.UserName,x.PictureFile,PictureType.User,null)));  
            CreateMap<User,UserAddDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();

            CreateMap<CreditAddDto, Credits>().ReverseMap();
            CreateMap<CreditUpdateDto, Credits>().ReverseMap();
            CreateMap<CarBrendModelUpdateDto, CarBrendModel>().ReverseMap();
        }
    }
}
