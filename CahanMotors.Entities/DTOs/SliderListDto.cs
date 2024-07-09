using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Entities.DTOs
{
    public class SliderListDto:DtoGetBase
    {
        public IList<Slider> Sliders { get; set; }
    }
}
