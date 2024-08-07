﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using CahanMotors.Entities.Concrete;
using CahanMotors.Mvc.Areas.Admin.Models;
using CahanMotors.Shared.Utilities.Helpers.Abstract;
using System.Threading.Tasks;

namespace CahanMotors.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OptionController : Controller
    {
        private readonly ChooseUsPageInfo _chooseUsPageInfo;
        private readonly IWritableOptions<ChooseUsPageInfo> _chooseUsPageInfoWriter;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;
        private readonly IToastNotification _toastNotification;
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteInfoWriter;
        private readonly SmtpSettings _smtpSettings;
        private readonly IWritableOptions<SmtpSettings> _smtpSettingsWriter;
        private readonly IMapper _mapper;
        public OptionController(
            IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo,
            IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter,
            IOptionsSnapshot<ChooseUsPageInfo> chooseUsPageInfo,
            IWritableOptions<ChooseUsPageInfo> chooseUsPageInfoWriter,
            IToastNotification toastNotification, IOptionsSnapshot<WebsiteInfo> websiteInfo,
            IWritableOptions<WebsiteInfo> websiteInfoWriter, IOptionsSnapshot<SmtpSettings> smtpSettings,
            IWritableOptions<SmtpSettings> smtpSettingsWriter, IMapper mapper)
        {
            _chooseUsPageInfo = chooseUsPageInfo.Value;
            _chooseUsPageInfoWriter = chooseUsPageInfoWriter;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _toastNotification = toastNotification;
            _websiteInfo = websiteInfo.Value;
            _websiteInfoWriter = websiteInfoWriter;
            _smtpSettings = smtpSettings.Value;
            _smtpSettingsWriter = smtpSettingsWriter;
            _mapper = mapper;
        }
        public IActionResult Choose()
        {
            return View(_chooseUsPageInfo);
        }
        [HttpPost]
        public IActionResult Choose(ChooseUsPageInfo chooseUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _chooseUsPageInfoWriter.Update(x =>
                {
                    x.Header = chooseUsPageInfo.Header;
                    x.ContentFirst = chooseUsPageInfo.ContentFirst;
                    x.ContentSecond = chooseUsPageInfo.ContentSecond;
                    x.ContentThird = chooseUsPageInfo.ContentThird;
                    x.ContentFourth = chooseUsPageInfo.ContentFourth;
                });
                _toastNotification.AddSuccessToastMessage("ChooseUs bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(chooseUsPageInfo);
            }
            return View(chooseUsPageInfo);
        }
        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }
        [HttpPost]
        public IActionResult About(AboutUsPageInfo aboutUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _aboutUsPageInfoWriter.Update(x =>
                {
                    x.Header = aboutUsPageInfo.Header;
                    x.Content = aboutUsPageInfo.Content;
                    x.SeoAuthor = aboutUsPageInfo.SeoAuthor;
                    x.SeoDescription = aboutUsPageInfo.SeoDescription;
                    x.SeoTags = aboutUsPageInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Haqqında bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(aboutUsPageInfo);
            }
            return View(aboutUsPageInfo);
        }
        [HttpGet]
        public IActionResult GeneralSettings()
        {
            return View(_websiteInfo);
        }
        [HttpPost]
        public IActionResult GeneralSettings(WebsiteInfo websiteInfo)
        {
            if (ModelState.IsValid)
            {
                _websiteInfoWriter.Update(x =>
                {
                    x.Title = websiteInfo.Title;
                    x.MenuTitle = websiteInfo.MenuTitle;
                    x.SeoAuthor = websiteInfo.SeoAuthor;
                    x.SeoDescription = websiteInfo.SeoDescription;
                    x.SeoTags = websiteInfo.SeoTags;
                    x.Facebook = websiteInfo.Facebook;
                    x.Instagram = websiteInfo.Instagram;
                    x.Youtube = websiteInfo.Youtube;
                    x.Whatsapp = websiteInfo.Whatsapp;
                    x.Phone = websiteInfo.Phone;
                    x.Phone2 = websiteInfo.Phone2;
                    x.Location = websiteInfo.Location;
                    x.Email = websiteInfo.Email;
                    x.Instagram2 = websiteInfo.Instagram2;
                });
                _toastNotification.AddSuccessToastMessage("Esas emeliyyatlar bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(websiteInfo);
            }
            return View(websiteInfo);
        }
        [HttpGet]
        public IActionResult EmailSettings()
        {
            return View(_smtpSettings);
        }
        [HttpPost]
        public IActionResult EmailSettings(SmtpSettings smtpSettings)
        {
            if (ModelState.IsValid)
            {
                _smtpSettingsWriter.Update(x =>
                {
                    x.Server = smtpSettings.Server;
                    x.Port = smtpSettings.Port;
                    x.SenderEmail = smtpSettings.SenderEmail;
                    x.SenderName = smtpSettings.SenderName;
                    x.Username = smtpSettings.Username;
                    x.Password = smtpSettings.Password;
                });
                _toastNotification.AddSuccessToastMessage("Saytin Email(Smtp) emeliyyatlar bölməsi uğurla editləndi.", new ToastrOptions
                {
                    Title = "Uğurlu Əməliyyat"
                });
                return View(smtpSettings);
            }
            return View(smtpSettings);
        }

    }
}
