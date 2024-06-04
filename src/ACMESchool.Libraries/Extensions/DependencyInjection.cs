using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ACMESchool.Libraries.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLibraries(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("ACMEDb"));
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            services.AddTransient<ICourse, CourseService>();
            services.AddTransient<IStudent, StudentService>();
            services.AddTransient<ICourseStudentRelation, CourseStudentRelationService>();
            services.AddTransient<IPaymentGateway, PaymentGatewayService>();
            return services;
        }
    }
}
