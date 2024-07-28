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
        public CreditViewComponent(ICarBrendModelService carBrendModelService, ICreditService creditService)
        {
            _carBrendModelService = carBrendModelService;
            _creditService = creditService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = _carBrendModelService.GetAllByNonDeletedAndActive().Result.Data.CarBrendModels.Where(x => x.ParentId > 0).ToList();
            var credits = _creditService.GetAllByNonDeletedAndActive();
            return View(new CarFilterViewModel
            {
                CarModels = models,
                Credits = credits.Result.Data.Credits
            });
        }
    }
}
