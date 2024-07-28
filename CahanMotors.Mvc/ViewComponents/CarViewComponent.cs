using Microsoft.AspNetCore.Mvc;
using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;

using System.Threading.Tasks;

namespace CahanMotors.Mvc.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private readonly ICarService _articleService;
        public CarViewComponent(ICarService articleService)
        {
            _articleService = articleService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articlesResult = await _articleService.GetAllByPaging(null, null,1, 8, false);
            return View(new CarHomeViewModel
            {
                CarListDto = articlesResult.Data
            });
        }
    }
}
