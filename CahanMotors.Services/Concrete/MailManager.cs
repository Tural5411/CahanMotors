﻿using Microsoft.Extensions.Options;
using CahanMotors.Shared.Utilities.Results.Abstract;
using CahanMotors.Shared.Utilities.Results.ComplexTypes;
using CahanMotors.Shared.Utilities.Results.Concrete;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;
using CahanMotors.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Services.Concrete
{
    public class MailManager : IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress(emailSendDto.Email) },
                Subject = emailSendDto.Subject,
                IsBodyHtml = true,
                Body = emailSendDto.Message
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential { UserName = _smtpSettings.Username, Password = _smtpSettings.Password },
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);
            return new Result(ResultStatus.Succes, "Mailiniz uğurla göndərildi");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress(emailSendDto.Email) },
                Subject = emailSendDto.Subject,
                IsBodyHtml = true,
                Body = $"Gonderen kisi {emailSendDto.Name}, gonderen email {emailSendDto.Email} <br/> {emailSendDto.Message}"
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = true, 
                Credentials = new NetworkCredential { UserName = _smtpSettings.Username, Password = _smtpSettings.Password },
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);
            return new Result(ResultStatus.Succes, "Mailiniz uğurla göndərildi");
        }
    }
}
