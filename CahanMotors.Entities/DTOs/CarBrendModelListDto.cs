using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Entities.Abstract;

namespace CahanMotors.Entities.DTOs
{
    public class CarBrendModelListDto : DtoGetBase
    {
        public IList<CarBrendModel> CarBrendModels { get; set; }
    }
}
