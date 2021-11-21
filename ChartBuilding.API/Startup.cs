using ChartBuilding.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChartBuilding.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "_angularCors";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSqlServer(Configuration.GetConnectionString("ChartConnectionString"));
            services.AddMapper();
            services.AddServiceDependency();
            services.AddRepositoryDependency();
            services.AddControllers().ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            services.AddCors(policy =>
            {
                policy.AddPolicy(name: _policyName, pol =>
                {
                    pol.WithOrigins("http://localhost:4200", "https://localhost:4200");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection()
                .UseCors(_policyName)
                .UseRouting()
                .UseAuthentication()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
