using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Data.Abstract
{
    public interface IPhotoRepository : IEntityRepository<CarPhotos>
    {
    }
}
