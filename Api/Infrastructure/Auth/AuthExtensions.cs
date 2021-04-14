using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Auth
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(AzureADB2CDefaults.BearerAuthenticationScheme)
                .AddAzureADB2CBearer(options => configuration.Bind("AzureAdB2C", options));

            services.AddAuthorization();
            
            // services
            //     .AddAuthorization(options =>
            //     {
            //         options.AddPolicy("AADConsumer", new AuthorizationPolicyBuilder()
            //             .RequireAuthenticatedUser()
            //             .AddAuthenticationSchemes("AAD")
            //             .Build());
            //
            //         options.AddPolicy("B2CBusiness", new AuthorizationPolicyBuilder()
            //             .RequireAuthenticatedUser()
            //             .AddAuthenticationSchemes("B2C")
            //             .Build());
            //     });

            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}