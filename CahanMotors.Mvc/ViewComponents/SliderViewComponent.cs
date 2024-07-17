using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CahanMotors.Entities.Concrete;
using CahanMotors.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CahanMotors.Services.Abstract;

namespace CahanMotors.Mvc.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var slider = _sliderService.GetAllByNonDeletedAndActive();
            return View(slider.Result.Data);
        }
    }
}
