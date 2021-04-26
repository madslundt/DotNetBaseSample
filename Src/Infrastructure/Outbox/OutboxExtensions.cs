using System;
using Infrastructure.MessageBrokers;
using Infrastructure.Outbox.Stores.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Outbox
{
    public static class OutboxExtensions
    {
        public static IServiceCollection AddEfCoreOutbox(this IServiceCollection services, IConfiguration configuration, Action<DbContextOptionsBuilder> dbContextOptions = null)
        {
            services.AddEfCoreOutboxStore(dbContextOptions);
            services.AddOutbox(configuration);

            return services;
        }

        private static IServiceCollection AddOutbox(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new OutboxOptions();
            configuration.GetSection(nameof(OutboxOptions)).Bind(options);
            services.Configure<OutboxOptions>(configuration.GetSection(nameof(OutboxOptions)));
            
            services.AddScoped<IOutboxListener, OutboxListener>();
            services.AddHostedService<OutboxProcessor>();

            return services;
        }
    }
}