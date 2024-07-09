using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Entities.DTOs
{
    public class RegisterDto:DtoGetBase
    {
        public Registers Team { get; set; }
    }
}
