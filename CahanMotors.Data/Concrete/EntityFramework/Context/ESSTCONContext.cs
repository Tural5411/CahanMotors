using CahanMotors.Data.Concrete.EntityFramework.Mappings;
using CahanMotors.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CahanMotors.Data.Concrete.EntityFramework.Context
{
    public class CahanMotorsContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<CarPhotos> CarPhotos { get; set; }
        public DbSet<Registers> Registers { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public CahanMotorsContext(DbContextOptions<CahanMotorsContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString:
        //    "data source=DESKTOP-RJ4V287\\SQLEXPRESS;initial catalog=CahanMotors;integrated security=True;MultipleActiveResultSets=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CarMap());
            modelBuilder.ApplyConfiguration(new SliderMap());
            modelBuilder.ApplyConfiguration(new RegistersMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new QuestionsMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserTokenMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new UserLoginMap());
            modelBuilder.ApplyConfiguration(new RoleClaimMap());
            modelBuilder.ApplyConfiguration(new UserClaimMap());
        }
    }
}
