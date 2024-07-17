using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using CahanMotors.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;

namespace CahanMotors.Mvc.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly AboutUsPageInfo _chooseUsPageInfo;
        private readonly IQuestionService _questionService;
        public AboutViewComponent(IOptions<AboutUsPageInfo> chooseUsPageInfo, IQuestionService questionService)
        {
            _chooseUsPageInfo = chooseUsPageInfo.Value;
            _questionService = questionService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var questions = await _questionService.GetAllByNonDeletedAndActive();
            return View(new AboutViewModel
            {
                AboutUsPageInfo = _chooseUsPageInfo,
                Questions = questions.Data
            });
        }
    }
}
