using CahanMotors.Shared.Entities.Abstract;
using CahanMotors.Shared.Utilities.Results.ComplexTypes;
using CahanMotors.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Entities.DTOs
{
    public class PhotoListDto : DtoGetBase
    {
        public IList<CarPhotos> Photos { get; set; }
    }
}
