using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Entities.Abstract;

namespace CahanMotors.Entities.DTOs
{
    public class CarBrendModelUpdateDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
