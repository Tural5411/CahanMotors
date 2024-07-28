using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace CahanMotors.Entities.DTOs
{
    public class CreditListDto : DtoGetBase
    {
        public IList<Credits> Credits { get; set; }
        public IList<CarBrendModel> CarBrendModels { get; set; }
    }
}
