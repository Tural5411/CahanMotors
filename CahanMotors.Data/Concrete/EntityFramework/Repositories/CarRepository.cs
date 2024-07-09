using CahanMotors.Data.Abstract;
using CahanMotors.Entities.Concrete;
using CahanMotors.Shared.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace CahanMotors.Data.Concrete.EntityFramework.Repositories
{
    public class CarRepository : EfEntityRepositoryBase<Car>, ICarRepository
    {
        public CarRepository(DbContext Context) : base(Context)
        {
        }
    }
}
