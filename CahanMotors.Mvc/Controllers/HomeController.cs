using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
//using CahanMotors.Mvc.Models;
using CahanMotors.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using System.Xml;

namespace CahanMotors.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IRegisterService _registerService;
        private readonly IToastNotification _toastNotification;


        public HomeController(IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IRegisterService registerService, IToastNotification toastNotification, IMailService mailService)
        {

            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _registerService = registerService;
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
        public IActionResult Testdrive()
        {
            return View();
        }

        [HttpPost]
        [Route("sinaq")]
        public IActionResult Testdrive(RegisterAddDto model)
        {
            var result = _registerService.Add(model, "Cahanmotors");
           
                _toastNotification.AddSuccessToastMessage("Göndərildi", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat",
                    CloseButton = true,
                    ProgressBar = true,
                    HideDuration = 4
                });
                return View();
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
