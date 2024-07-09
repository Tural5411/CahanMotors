//using AutoMapper;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using NToastNotify;
//using CahanMotors.Entities.ComplexTypes;
//using CahanMotors.Entities.Concrete;
//using CahanMotors.Entities.DTOs;
//using CahanMotors.Mvc.Areas.Admin.Helpers.Abstract;
//using CahanMotors.Mvc.Areas.Admin.Models;
//using CahanMotors.Services.Abstract;
//using CahanMotors.Shared.Utilities.Results.ComplexTypes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace CahanMotors.Mvc.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class RegisterController : BaseController
//    {
//        private readonly ICarService _carService;
//        private readonly IToastNotification _toastNotification;

//        public RegisterController(ICarService carService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
//        {
//            _carService = carService;
//            _toastNotification = toastNotification;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var result = await _carService.GetAll();
//            return View(result.Data);
//        }
//        [HttpGet]
//        public IActionResult Add()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Add(CarAddDto carAddDto)
//        {
//            if (ModelState.IsValid)
//            {
//                //var videoAddDto = Mapper.Map<VideoAddDto>(videoAddViewModel);
//                var imageResult = await ImageHelper.UploadImage(carAddDto.Name,
//                    carAddDto.PictureFile, PictureType.Post);
//                videoAddDto.Thumbnail = imageResult.Data.FullName;
//                var result = await _videoService.Add(videoAddDto, LoggedInUser.UserName);
//                if (result.ResultStatus == ResultStatus.Succes)
//                {
//                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
//                    {
//                        Title = "Uğurlu əməliyyat"
//                    });
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    ModelState.AddModelError("", result.Message);
//                }
//            }
//            return View(videoAddViewModel);
//        }
//        [HttpGet]
//        public async Task<IActionResult> Update(int videoId)
//        {
//            var result = await _videoService.GetVideoUpdateDto(videoId);
//            if (result.ResultStatus == ResultStatus.Succes)
//            {
//                var videoUpdateViewModel = Mapper.Map<CarUpdateViewModel>(result.Data);
//                return View(videoUpdateViewModel);
//            }
//            return NotFound();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Update(CarUpdateViewModel videoUpdateViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                bool isNewThumbnailUploaded = false;
//                var oldThumbnail = videoUpdateViewModel.Thumbnail;
//                if (videoUpdateViewModel.PictureFile != null)
//                {
//                    var uploadedImageResult = await ImageHelper.UploadImage(videoUpdateViewModel.Title,
//                        videoUpdateViewModel.PictureFile, PictureType.Post);
//                    videoUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus
//                        == ResultStatus.Succes ? uploadedImageResult.Data.FullName
//                        : "postImages/defaultThumbnail.jpg";
//                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
//                    {
//                        isNewThumbnailUploaded = true;
//                    }
//                }
//                var videoUpdateDto = Mapper.Map<VideoUpdateDto>(videoUpdateViewModel);
//                var result = await _videoService.Update(videoUpdateDto, LoggedInUser.UserName);
//                if (result.ResultStatus == ResultStatus.Succes)
//                {
//                    if (isNewThumbnailUploaded)
//                    {
//                        ImageHelper.ImageDelete(oldThumbnail);
//                    }
//                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
//                    {
//                        Title = "Uğurlu əməliyyat",
//                        CloseButton = true
//                    });
//                    return RedirectToAction("Index");
//                }
//                else
//                {
//                    ModelState.AddModelError("", result.Message);
//                }
//            }
//            return View(videoUpdateViewModel);
//        }
//        [HttpPost]
//        public async Task<JsonResult> Delete(int videoId)
//        {
//            var result = await _videoService.HardDelete(videoId);
//            var deletedVideo = JsonSerializer.Serialize(result);
//            return Json(deletedVideo);
//        }
//    }
//}
