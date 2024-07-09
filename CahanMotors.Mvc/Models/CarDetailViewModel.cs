using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CahanMotors.Entities.DTOs;

namespace CahanMotors.Mvc.Models
{
    public class CarDetailViewModel
    {
        public CarDto CarDto { get; set; }
        public PhotoListDto CarPhotos { get; set; }
    }
}
