﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CahanMotors.Shared.Utilities.Results.ComplexTypes;
using CahanMotors.Entities.Concrete;
using CahanMotors.Mvc.Areas.Admin.Models;
using CahanMotors.Services.Abstract;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<User> _userManager;

        public HomeController(IArticleService articleService, UserManager<User> userManager)
        {
            _articleService = articleService;
            _userManager = userManager;
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        public async Task<IActionResult> Index()
        {
            var articlesCountResult = await _articleService.CountByNonDeleted();
            var usersCount = await _userManager.Users.CountAsync();
            var articlesResult = await _articleService.GetAll();
            if (articlesCountResult.ResultStatus == ResultStatus.Succes
                && usersCount > -1
                && articlesResult.ResultStatus == ResultStatus.Succes)
            {
                return View(new DashboardViewModel
                {
                    ArticleCount = articlesCountResult.Data,
                    UserCount = usersCount,
                    Articles = articlesResult.Data
                });
            }
            return NotFound();
        }
    }
}
