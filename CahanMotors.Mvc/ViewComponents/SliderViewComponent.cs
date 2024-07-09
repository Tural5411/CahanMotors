//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using CahanMotors.Entities.Concrete;
//using CahanMotors.Mvc.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CahanMotors.Mvc.ViewComponents
//{
//    public class SliderViewComponent : ViewComponent
//    {
//        private readonly Slider _sliderPageInfo;
//        public SliderViewComponent(IOptionsSnapshot<Slider> sliderPageInfo)
//        {
//            _sliderPageInfo = sliderPageInfo.Value;
//        }
//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            return View(_sliderPageInfo);
//        }
//    }
//}
