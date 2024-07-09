using CahanMotors.Shared.Concrete.EntityFramework;
using CahanMotors.Data.Abstract;
using CahanMotors.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CahanMotors.Data.Concrete.EntityFramework.Repositories
{
    public class SliderRepository : EfEntityRepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(DbContext Context) : base(Context)
        {
        }
    }
}
