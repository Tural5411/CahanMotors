using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;

using System.Threading.Tasks;

namespace CahanMotors.Mvc.ViewComponents
{
    public class CarFilterViewComponent : ViewComponent
    {
        private readonly ICarBrendModelService _carBrendModelService;
        public CarFilterViewComponent(ICarBrendModelService carBrendModelService)
        {
            _carBrendModelService = carBrendModelService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brends = _carBrendModelService.GetAll().Result.Data.CarBrendModels.Where(x => x.ParentId == 0).ToList();
            var models = _carBrendModelService.GetAll().Result.Data.CarBrendModels.Where(x => x.ParentId > 0).ToList();
            return View(new CarFilterViewModel
            {
                CarBrends = brends,
                CarModels = models
            });
        }
    }
}
