using Nikolaeva_kt_43_21.Filters.TeacherInterfaces;
using Nikolaeva_kt_43_21.Interfaces.TeacherInterfaces;

namespace Nikolaeva_kt_43_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherGetterService, TeacherGetterService>();
            services.AddScoped<ITeacherModifierService, TeacherModifierService>();
            return services;
        }
    }
}
