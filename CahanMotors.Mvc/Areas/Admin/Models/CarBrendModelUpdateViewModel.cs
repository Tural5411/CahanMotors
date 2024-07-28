﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CahanMotors.Entities.Concrete;

namespace CahanMotors.Mvc.Areas.Admin.Models
{
    public class CarBrendModelUpdateViewModel
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Aktivdir ?")]
        [Required(ErrorMessage = "{0}  boş ola bilməz!")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CreditUpdateViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Period { get; set; }
        public decimal MonthlyPay { get; set; }
        public decimal CarPrice { get; set; }
        public decimal InitialPayment { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

