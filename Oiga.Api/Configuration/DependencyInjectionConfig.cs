using Oiga.Bussines.Interface;
using Oiga.Bussines.Service;
using Oiga.Infra.Repository;

namespace Oiga.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<INotification, NotificationService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEvaluationService, EvaluationService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
