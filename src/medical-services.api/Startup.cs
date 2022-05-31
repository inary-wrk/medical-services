using businesslogic;
using datalayer;
using FluentValidation.AspNetCore;
using MediatR;
using medical_services.api.Mapper;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace medical_services.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            })
            .AddFluentValidation();

            services.AddSwaggerGen(options =>
            {
                options.SupportNonNullableReferenceTypes();
                options.CustomSchemaIds(type => type.FullName?.Replace("+", "_"));
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "medical_services.api", Version = "v1" });
            });
            services.AddFluentValidationRulesToSwagger();

            services.AddMediatR(typeof(Startup));
            services.RegisterDatalayer(Configuration);
            services.RegisterBusinesslogic();
            services.RegisterMapper();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "medical_services.api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
