using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CahanMotors.Data.Abstract.UnitOfWorks;
using CahanMotors.Data.Concrete.UnitOfWork;
using CahanMotors.Entities.Concrete;
using CahanMotors.Services.Abstract;
using CahanMotors.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CahanMotors.Data.Concrete.EntityFramework.Context;

namespace CahanMotors.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection,string connectionString)
        {
            serviceCollection.AddDbContext<CahanMotorsContext>(options=>options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            serviceCollection.AddIdentity<User, Role>(options => {
                //User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                //User UserName and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<CahanMotorsContext>();
            serviceCollection.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(15);
            });
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IQuestionService, QuestionManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            serviceCollection.AddScoped<ISliderService, SliderManager>();
            serviceCollection.AddScoped<ICarService, CarManager>();
            serviceCollection.AddScoped<IRegisterService, RegisterManager>();
            serviceCollection.AddSingleton<IMailService, MailManager>();
            serviceCollection.AddScoped<IPhotoService, PhotoManager>();
            return serviceCollection;
        }
    }
}
