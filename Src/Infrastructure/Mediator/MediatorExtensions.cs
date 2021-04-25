using System;
using System.Linq;
using FluentValidation.AspNetCore;
using Infrastructure.MediatorPipelines;
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
            var assemblies = types.Select(type => type.Assembly).ToList();

            foreach (var assembly in assemblies)
            {
                services.AddMediatR(assembly);
            }

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LogPreProcessor<>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LogPostProcessor<,>));

            services
                .AddMvc(opt => { opt.Filters.Add<TFilterMetadata>(); })
                .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblies(assemblies); });

            return services;
        }
    }
}