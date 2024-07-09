using AutoMapper;
using CahanMotors.Entities.Concrete;
using CahanMotors.Mvc.Areas.Admin.Models;
using CahanMotors.Entities.DTOs;


namespace CahanMotors.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile:Profile
    {
        public ViewModelsProfile()  
        {
            CreateMap<CarAddViewModel, CarAddDto>();
            CreateMap<CarAddDto, CarAddViewModel>();
            CreateMap<CarUpdateDto, CarUpdateViewModel>().ReverseMap();

            CreateMap<PhotoAddDto, PhotoAddViewModel>().ReverseMap();

            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateViewModel, ArticleUpdateDto>();
            CreateMap<ArticleUpdateDto,ArticleUpdateViewModel>();
        }
    }
}
