﻿using System.Collections.Generic;
using AutoMapper;
using CahanMotors.Entities.ComplexTypes;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using CahanMotors.Mvc.Areas.Admin.Helpers.Abstract;
using CahanMotors.Mvc.Areas.Admin.Models;
using CahanMotors.Services.Abstract;
using CahanMotors.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

namespace CahanMotors.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        private readonly ICarBrendModelService _carbrendModelService;
        private readonly IToastNotification _toastNotification;
        private readonly IPhotoService _photoService;

        public CarController(ICarBrendModelService carbrendModelService, IPhotoService photoService, ICarService carService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _carService = carService;
            _toastNotification = toastNotification;
            _photoService = photoService;
            _carbrendModelService = carbrendModelService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _carService.GetAllByNonDeleteAndActive();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var brends = _carbrendModelService.GetAllByNonDeletedAndActive().Result.Data.CarBrendModels.Where(x => x.ParentId == 0).ToList();
            var models = _carbrendModelService.GetAllByNonDeletedAndActive().Result.Data.CarBrendModels.Where(x => x.ParentId > 0).ToList();
            return View(new CarAddViewModel
            {
                CarBrends = brends,
                CarModels = models
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(CarAddViewModel carAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var carAddDto = Mapper.Map<CarAddDto>(carAddViewModel);
                var imageResult = await ImageHelper.UploadImage(carAddViewModel.Name,
                    carAddViewModel.PictureFile, PictureType.Post);
                carAddDto.ThumbNail = imageResult.Data.FullName;
                var result = await _carService.Add(carAddDto, LoggedInUser.UserName);

                if (carAddViewModel.CarPhotos != null)
                {
                    carAddViewModel.Photos = new List<PhotoAddViewModel>();
                    foreach (var file in carAddViewModel.CarPhotos)
                    {
                        var galleryResult = await ImageHelper.UploadImageV2(file);
                        var gallery = new PhotoAddDto()
                        {
                            CarId = result.Data.Car.Id,
                            ImageUrl = galleryResult
                        };
                        await _photoService.Add(gallery, "CahanMotors");
                    }
                }

                if (result.ResultStatus == ResultStatus.Succes)
                {
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Uğurlu əməliyyat"
                    });
                    return RedirectToAction("Index", "Car", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            var brends = _carbrendModelService.GetAllByNonDeletedAndActive().Result.Data.CarBrendModels.Where(x => x.ParentId == 0).ToList();
            var models = _carbrendModelService.GetAllByNonDeletedAndActive().Result.Data.CarBrendModels.Where(x => x.ParentId > 0).ToList();

            carAddViewModel.CarBrends = brends;
            carAddViewModel.CarModels = models;
            return View(carAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int carId)
        {
            var result = await _carService.GetUpdateDto(carId);
            var images = await _photoService.GetAllByNonDeletedAndActive(carId);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                var teamUpdateViewModel = Mapper.Map<CarUpdateViewModel>(result.Data);
                teamUpdateViewModel.Images = images.Data.Photos;
                return View(teamUpdateViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarUpdateViewModel teamUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = teamUpdateViewModel.Thumbnail;
                if (teamUpdateViewModel.PictureFile != null)
                {
                    var uploadedImageResult = await ImageHelper.UploadImage(teamUpdateViewModel.Name,
                        teamUpdateViewModel.PictureFile, PictureType.Post);
                    teamUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus
                        == ResultStatus.Succes ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var teamUpdateDto = Mapper.Map<CarUpdateDto>(teamUpdateViewModel);
                var result = await (_carService).Update(teamUpdateDto, LoggedInUser.UserName);


                ////Multi Image
                //if (teamUpdateViewModel.CarPhotos != null)
                //{
                //    teamUpdateViewModel.p = new List<PhotoAddViewModel>();
                //    foreach (var file in projectUpdateViewModel.ProjectPhotos)
                //    {
                //        var galleryResult = await ImageHelper.UploadImageV2(file);
                //        var gallery = new PhotoAddDto()
                //        {
                //            ProjectId = result.Data.Project.Id,
                //            URL = galleryResult
                //        };
                //        await _photoService.Add(gallery, "Damplus");
                //    }
                //}

                if (result.ResultStatus == ResultStatus.Succes)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.ImageDelete(oldThumbnail);
                    }
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Uğurlu əməliyyat",
                        CloseButton = true
                    });
                    return RedirectToAction("Index", "Car", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(teamUpdateViewModel);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int teamId)
        {
            var result = await (_carService).Delete(teamId, LoggedInUser.UserName);
            var deletedTeam = JsonSerializer.Serialize(result);
            return Json(deletedTeam);
        }

        [HttpPost]
        public async Task<JsonResult> DeletePhoto(int photoId)
        {
            var result = await _photoService.HardDelete(photoId);
            var deletedTeam = JsonSerializer.Serialize(result);
            return Json(deletedTeam);
        }

        public async Task<JsonResult> GetModels(int brandId)
        {
            var models = (await _carbrendModelService.GetAllByNonDeletedAndActive()).Data.CarBrendModels
                                  .Where(m => m.ParentId == brandId)
                                  .Select(m => new { m.Id, m.Name })
                                  .ToList();
            return Json(models);
        }


    }
}
