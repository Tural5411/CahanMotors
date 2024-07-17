using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CahanMotors.Shared.Entities.Concrete;

namespace CahanMotors.Entities.Concrete
{
    public class CarBrendModel:EntityBase
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
