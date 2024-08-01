using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;

using System.Threading.Tasks;

namespace CahanMotors.Mvc.ViewComponents
{
    public class CreditViewComponent : ViewComponent
    {
        private readonly ICarBrendModelService _carBrendModelService;
        private readonly ICreditService _creditService;
        private readonly ICarService _carService;
        public CreditViewComponent(ICarService carService,ICarBrendModelService carBrendModelService, ICreditService creditService)
        {
            _carBrendModelService = carBrendModelService;
            _creditService = creditService;
            _carService = carService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cars = _carService.GetAllByNonDeleteAndActive().Result.Data.Cars;
            var credits = _creditService.GetAllByNonDeletedAndActive().Result.Data.Credits;

            var models = _carBrendModelService.GetAllByNonDeletedAndActive().Result.Data.CarBrendModels
                .Where(x => x.ParentId > 0)
                .ToList();

            var carModelIds = cars.Select(c => c.ModelId).ToHashSet();
            var creditModelIds = credits.Select(c => c.ModelId).ToHashSet();

            var commonModels = models.Where(m => carModelIds.Contains(m.Id) && creditModelIds.Contains(m.Id)).ToList();

            return View(new CarFilterViewModel
            {
                CarModels = commonModels,
                Credits = credits
            });

        }
    }
}
