using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;

namespace CahanMotors.Mvc.Models
{
    public class AboutViewModel
    {
        public AboutUsPageInfo AboutUsPageInfo { get; set; }
        public QuestionListDto Questions { get; set; }
    }
}
