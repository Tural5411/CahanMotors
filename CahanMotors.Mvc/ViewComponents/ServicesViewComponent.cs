//using Microsoft.AspNetCore.Mvc;
//using CahanMotors.Mvc.Models;
//using CahanMotors.Services.Abstract;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CahanMotors.Mvc.ViewComponents
//{
//    public class ServicesViewComponent:ViewComponent
//    {
//        private readonly IBusinessService _businessService;
//        public ServicesViewComponent(IBusinessService businessService)
//        {
//            _businessService = businessService;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var BusinessResult = await _businessService.GetAll();
//            return View(new BusinessViewModel
//            {
//                  BusinessListDto= BusinessResult.Data
//            });
//        }
//    }
//}
