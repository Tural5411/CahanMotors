using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using CahanMotors.Entities.ComplexTypes;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using CahanMotors.Mvc.Areas.Admin.Helpers.Abstract;
using CahanMotors.Mvc.Areas.Admin.Models;
using CahanMotors.Services.Abstract;
using CahanMotors.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : BaseController
    {
        private readonly IRegisterService _RegisterService;
        private readonly IToastNotification _toastNotification;

        public RegisterController(IRegisterService RegisterService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _RegisterService = RegisterService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _RegisterService.GetAll();
            return View(result.Data);
        }
        
        [HttpPost]
        public async Task<JsonResult> Delete(int registerId)
        {
            var result = await _RegisterService.Delete(registerId, LoggedInUser.UserName);
            var deletedVideo = JsonSerializer.Serialize(result);
            return Json(deletedVideo);
        }
    }
}
