using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SWA240605_WebAPI.Application.Interfaces;
using SWA240605_WebAPI.Domain.Settings;
using SWA240605_WebAPI.Shared.Services;

namespace SWA240605_WebAPI.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSetting>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
