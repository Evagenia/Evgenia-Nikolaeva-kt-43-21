using Nikolaeva_kt_43_21.Interfaces.TeacherInterfaces;

namespace Nikolaeva_kt_43_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }
}
