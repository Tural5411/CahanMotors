using CahanMotors.Shared.Concrete.EntityFramework;
using CahanMotors.Data.Abstract;
using CahanMotors.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CahanMotors.Data.Concrete.EntityFramework.Repositories
{
    public class RegisterRepository : EfEntityRepositoryBase<Registers>, IRegisterRepository
    {
        public RegisterRepository(DbContext Context) : base(Context)
        {
        }
    }
}
