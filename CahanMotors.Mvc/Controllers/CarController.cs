using CahanMotors.Entities.Concrete;
using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;
using CahanMotors.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICreditService _creditService;
        private readonly ICarBrendModelService _carBrendModelService;
        private readonly IPhotoService _photoService;

        public CarController(ICreditService creditService,ICarService carService, ICarBrendModelService carBrendModelService, IPhotoService photoService)
        {
            _carService = carService;
            _creditService = creditService;
            _photoService = photoService;
            _carBrendModelService = carBrendModelService;
        }
        [Route("Modeller")]
        [HttpGet]
        public async Task<IActionResult> Index(int? brendId, int? modelId, int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            var articleResult = await _carService.GetAllByPaging(brendId, modelId, currentPage, pageSize, isAscending);
            return View(articleResult.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int articleId)
        {
            var articleResult = await _carService.Get(articleId);
            var carPhotosResult = await _photoService.GetAllByNonDeletedAndActive(articleId);

            if (articleResult.ResultStatus == ResultStatus.Succes)
            {
                return View(new CarDetailViewModel
                {
                    CarDto = articleResult.Data,
                    CarPhotos = carPhotosResult.Data
                });
            }
            return NotFound();
        }
        [HttpGet]
        public JsonResult GetCreditDetails(int modelId,int period)
        {
            var creditDetails = _creditService.GetAllByNonDeletedAndActive().Result.Data.Credits.FirstOrDefault(x => x.ModelId == modelId && x.Period == period);

            return Json(new
            {
                initialPayment = creditDetails.InitialPayment,
                period = creditDetails.Period,
                monthlyPayment = creditDetails.MonthlyPay,
                carPrice = creditDetails.CarPrice
            });
        }

    }
}
