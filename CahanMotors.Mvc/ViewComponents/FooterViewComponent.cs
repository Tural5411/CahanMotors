//using Microsoft.AspNetCore.Mvc;
//using CahanMotors.Mvc.Models;
//using CahanMotors.Services.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CahanMotors.Mvc.ViewComponents
//{
//    public class FooterViewComponent : ViewComponent
//    {
//        private readonly IBusinessService _articleService;
//        public FooterViewComponent(IBusinessService articleService)
//        {
//            _articleService = articleService;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var articlesResult = await _articleService.GetAllByNonDeleteAndActive();
//            return View(new HeaderViewModel
//            {
//                BusinessListDto = articlesResult.Data,
//            });
//        }
//    }
//}
