using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;

using System.Threading.Tasks;

namespace CahanMotors.Mvc.ViewComponents
{
    public class CreditDetailViewComponent : ViewComponent
    {
        private readonly ICarBrendModelService _carBrendModelService;
        private readonly ICreditService _creditService;
        public CreditDetailViewComponent(ICarBrendModelService carBrendModelService, ICreditService creditService)
        {
            _carBrendModelService = carBrendModelService;
            _creditService = creditService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var credits = _creditService.GetAllByNonDeletedAndActive();
            return View(new CarFilterViewModel
            {
                Credits = credits.Result.Data.Credits
            });
        }
    }
}
