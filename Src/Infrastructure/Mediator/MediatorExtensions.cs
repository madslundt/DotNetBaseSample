using System;
using System.Linq;
using FluentValidation.AspNetCore;
using Infrastructure.Commands;
using Infrastructure.Events;
using Infrastructure.MediatorPipelines;
using Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mediator
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediator<TFilterMetadata>(this IServiceCollection services,
            params Type[] types)
            where TFilterMetadata : IFilterMetadata
        {
            services.AddMediatR(types);
            
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            
            var assemblies = types.Select(type => type.Assembly).ToList();

            services
                .AddControllers(opt =>
                {
                    opt.Filters.Add<TFilterMetadata>();
                    opt.SuppressAsyncSuffixInActionNames = false;
                })
                .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblies(assemblies); })
                .AddNewtonsoftJson();

            return services;
        }
    }
}