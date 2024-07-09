using CahanMotors.Shared.Entities.Abstract;
using CahanMotors.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Entities.Concrete
{
    public class Questions : EntityBase, IEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
