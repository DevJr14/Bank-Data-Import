using Application;

namespace WebApi
{
    internal static class ServiceCollectionExtensions
    {
        internal static AppSettings GetApplicationSettings(
              this IServiceCollection services,
              IConfiguration configuration)
        {
            var appSettings = configuration.GetSection(nameof(AppSettings));
            services.Configure<AppSettings>(appSettings);
            return appSettings.Get<AppSettings>();
        }
    }
}
