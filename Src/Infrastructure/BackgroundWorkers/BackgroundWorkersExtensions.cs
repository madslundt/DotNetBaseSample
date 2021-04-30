using System;
using Hangfire;
using Infrastructure.BackgroundWorkers.Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.BackgroundWorkers
{
    public static class BackgroundWorkersExtensions
    {
        public static IServiceCollection AddBackgroundWorkerClient(this IServiceCollection services, IConfiguration configuration, Action<IGlobalConfiguration> hangfireConfiguration)
        {
            var options = new HangfireOptions();
            configuration.GetSection(nameof(HangfireOptions)).Bind(options);
            services.Configure<HangfireOptions>(configuration.GetSection(nameof(HangfireOptions)));
            
            services.AddHangfire(configuration =>
            {
                hangfireConfiguration(configuration);
                configuration.UseHangfire();
            });
            
            return services;
        }

        public static IServiceCollection AddBackgroundWorkerServer(this IServiceCollection services)
        {
            services.AddHangfireServer();

            return services;
        }

        public static IApplicationBuilder UseBackgroundWorkerUI(this IApplicationBuilder app, HangfireOptions options)
        {
            app.UseHangfireDashboard(options.Path, options);

            return app;
        }
    }
}