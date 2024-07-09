using CahanMotors.Shared.Entities.Abstract;
using CahanMotors.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Entities.DTOs
{
    public class RoleListDto:DtoGetBase
    {
        public IList<Role> Roles { get; set; }
    }
}
