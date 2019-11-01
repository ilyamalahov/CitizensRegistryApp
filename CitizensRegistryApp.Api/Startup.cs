using CitizensRegistryApp.Api.Configuration;
using CitizensRegistryApp.Core.Data;
using CitizensRegistryApp.Core.Profiles;
using CitizensRegistryApp.Infrastructure.Data;
using CitizensRegistryApp.Infrastructure.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace CitizensRegistryApp.Api
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
            string connectionString = Configuration.GetConnectionString("SqlServerConnection");

            //AppOptions appOptions = Configuration.GetSection("App").Get<AppOptions>();

            services.AddTransient<IDbConnectionFactory>(_ => new DbConnectionFactory(connectionString));

            services.AddTransient<IProfilesRepository, ProfilesRepository>();

            string[] allowedHosts = Configuration.GetSection("AllowedHosts").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("SpaPolicy", policy => policy.WithOrigins(allowedHosts).AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("SpaPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
