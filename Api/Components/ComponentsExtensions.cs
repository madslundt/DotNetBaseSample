using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Components
{
    public static class ComponentsExtensions
    {
        public static IServiceCollection AddComponents(this IServiceCollection services, IConfiguration configuration)
        {
            // var options = new PhoneServiceOptions();
            // var config = configuration.GetSection(nameof(PhoneServiceOptions));
            // config.Bind(options);
            // services.Configure<PhoneServiceOptions>(config);

            // services.AddScoped<IPhoneService, TwilioAccountService>();

            return services;
        }
    }
}