using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CahanMotors.Entities.Concrete;
using CahanMotors.Entities.DTOs;

namespace CahanMotors.Mvc.Models
{
    public class CarHomeViewModel
    {
        public CarListDto CarListDto { get; set; }
    }
    public class CarFilterViewModel
    {
        public IList<CarBrendModel> CarModels { get; set; }
        public IList<CarBrendModel> CarBrends { get; set; }
        public IList<Credits> Credits { get; set; }
    }
}
