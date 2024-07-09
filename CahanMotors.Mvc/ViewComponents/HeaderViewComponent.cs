//using Microsoft.AspNetCore.Mvc;
//using CahanMotors.Mvc.Models;
//using CahanMotors.Services.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CahanMotors.Mvc.ViewComponents
//{
//    public class HeaderViewComponent:ViewComponent
//    {
//        private readonly IBusinessService _articleService;
//        private readonly IProjectCategoryService _categoryService;
//        public HeaderViewComponent(IBusinessService articleService, IProjectCategoryService categoryService)
//        {
//            _articleService = articleService;
//            _categoryService = categoryService;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var categories = await _categoryService.GetAllByNonDeleteAndActive();
//            var articlesResult = await _articleService.GetAllByNonDeleteAndActive();
//            return View(new HeaderViewModel
//            {
//                BusinessListDto = articlesResult.Data,
//                ProjectCategoryListDto= categories.Data
//            });
//        }
//    }
//}
