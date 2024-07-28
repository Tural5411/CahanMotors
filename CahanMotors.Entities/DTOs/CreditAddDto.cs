using CahanMotors.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CahanMotors.Entities.Concrete;

namespace CahanMotors.Entities.DTOs
{
    public class CreditAddDto
    {
        public int ModelId { get; set; }
        public int Period { get; set; }
        public decimal MonthlyPay { get; set; }
        public decimal CarPrice { get; set; }
        public decimal InitialPayment { get; set; }
        public bool IsActive { get; set; }
    }
}
