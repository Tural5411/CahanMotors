using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Entities.Abstract;
using System.Collections.Generic;

namespace CahanMotors.Entities.DTOs
{
    public class CarListDto:DtoGetBase
    {
        public IList<Car> Cars { get; set; }
        public int? CategoryId { get; set; }
    }
}
