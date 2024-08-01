using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using CahanMotors.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CahanMotors.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IRegisterService _registerService;
        private readonly ICarBrendModelService _carBrendModelService;
        private readonly ICarService _carService;
        private readonly IToastNotification _toastNotification;


        public HomeController(ICarService carService,ICarBrendModelService carBrendModelService,IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IRegisterService registerService, IToastNotification toastNotification, IMailService mailService)
        {
            _carBrendModelService = carBrendModelService;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _registerService = registerService;
            _carService= carService;
        }
        [Route("/sitemap.xml")]
        public void SitemapXml()
        {
            string host = Request.Scheme + "://" + Request.Host;

            Response.ContentType = "application/xml";

            using (var xml = XmlWriter.Create(Response.Body, new XmlWriterSettings { Indent = true }))
            {
                xml.WriteStartDocument();
                xml.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

                xml.WriteStartElement("url");
                xml.WriteElementString("loc", host);
                xml.WriteEndElement();

                xml.WriteEndElement();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("haqqimizda")]
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        [Route("sinaq")]
        public async Task<IActionResult> Testdrive(RegisterAddDto models, int? a)
        {
            var allCarsResult = await _carService.GetAllByNonDeleteAndActive();
            var allCars = allCarsResult.Data.Cars;

            var carBrendModelsResult = await _carBrendModelService.GetAllByNonDeletedAndActive();
            var carBrendModels = carBrendModelsResult.Data.CarBrendModels.Where(x => x.ParentId > 0);

            var carModelIds = allCars.Select(c => c.ModelId).ToHashSet();
            var commonModels = carBrendModels.Where(m => carModelIds.Contains(m.Id)).ToList();

            models.CarModels = commonModels;

            return View(models);
        }


        [HttpPost]
        [Route("sinaq")]
        public async Task<IActionResult> Testdrive(RegisterAddDto model)
        {
            
            var result = await _registerService.Add(model, "Cahanmotors");

            var allCarsResult = await _carService.GetAllByNonDeleteAndActive();
            var allCars = allCarsResult.Data.Cars;

            var carBrendModelsResult = await _carBrendModelService.GetAllByNonDeletedAndActive();
            var carBrendModels = carBrendModelsResult.Data.CarBrendModels.Where(x => x.ParentId > 0);

            var carModelIds = allCars.Select(c => c.ModelId).ToHashSet();
            var commonModels = carBrendModels.Where(m => carModelIds.Contains(m.Id)).ToList();

            model.CarModels = commonModels;


            _toastNotification.AddSuccessToastMessage("Göndərildi", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat",
                    CloseButton = true,
                    ProgressBar = true,
                    HideDuration = 4
                });
                return View(model);
        }

        [HttpGet]
        [Route("Elaqe")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("Elaqe")]
        [HttpPost]
        public IActionResult Contact(EmailSendDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(model);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat",
                    CloseButton = true,
                    ProgressBar = true,
                    HideDuration = 4
                });
                return View();
            }
            return View(model);
        }

    }
}
