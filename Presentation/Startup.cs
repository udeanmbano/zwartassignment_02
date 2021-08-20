using Application;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ZwartsJWTApi.Infrastructure;
using ZwartsJWTApi.Infrastructure.Data;

namespace Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddApplication();
            services.AddControllers();
             services.AddInfrastructure(Configuration);
            services.AddCors(); // Make sure you call this previous to AddMvc          

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() {Title = "ZwartsApi", Version = "v1"});
            });
            services.AddDbContext<ApplicationDbContext>(m => m.UseSqlServer(Configuration.GetConnectionString("ConnStr"),b=>b.MigrationsAssembly("ZwartsJWTApi")), ServiceLifetime.Singleton);
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "ZwartsApi"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials()
          );
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
           // app.UseSwagger();

           // app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS Forum v1"));
        }
    }
}