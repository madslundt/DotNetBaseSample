using Api.Filters;
using Api.Infrastructure.OptionKeys;
using Components;
using DataModel;
using Events;
using Infrastructure.Mediator;
using Infrastructure.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString(ConnectionStringKeys.Api)));
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(ConnectionStringKeys.Api));

            services.AddMediator<ExceptionFilter>(typeof(Startup), typeof(ComponentsExtensions), typeof(DatabaseContext), typeof(EventsExtensions))
                // .AddAuth(Configuration)
                .AddSwaggerDoc()
                .AddComponents(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }
            
            app.UsePathBase(new PathString("/api"));

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseSwaggerDoc();
        }
    }
}