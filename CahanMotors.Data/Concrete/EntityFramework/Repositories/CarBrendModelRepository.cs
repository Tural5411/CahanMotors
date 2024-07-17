using CahanMotors.Data.Abstract;
using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CahanMotors.Data.Concrete.EntityFramework.Repositories
{
    public class CarBrendModelRepository : EfEntityRepositoryBase<CarBrendModel>, ICarBrendModelRepository
    {
        public CarBrendModelRepository(DbContext Context) : base(Context)
        {
        }
    }
}
