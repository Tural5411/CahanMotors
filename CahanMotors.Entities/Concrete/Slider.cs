﻿using CahanMotors.Shared.Entities.Abstract;
using CahanMotors.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Entities.Concrete
{
    public class Slider : EntityBase, IEntity
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
