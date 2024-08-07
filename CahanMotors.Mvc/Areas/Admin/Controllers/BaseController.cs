﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CahanMotors.Entities.Concrete;
using CahanMotors.Mvc.Areas.Admin.Helpers.Abstract;

namespace CahanMotors.Mvc.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<User> UserManager { get;}

        public BaseController(UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper)
        {
            UserManager = userManager;
            Mapper = mapper;
            ImageHelper = imageHelper; 
        }

        protected IMapper Mapper { get; }
        protected IImageHelper ImageHelper { get; }
        protected User LoggedInUser => UserManager.GetUserAsync(HttpContext.User).Result;
    }
}
