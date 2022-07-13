using BackendAssessment.API.ConfigurationExtensions;
using BackendAssessment.API.MiddleWares;
using BackendAssessment.Infrastructure.Context;
using BackendAssessment.Infrastructure.Entities;
using BackendAssessment.Infrastructure.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BackendAssessment.Core.Utilities;
using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Core.Services.Implimentations;
using BackendAssessment.Infrastructure.Repository.Interface;
using BackendAssessment.Infrastructure.Repository.Implimentation;
using BackendAssessment.Infrastructure.AutoMapper;

namespace BackendAssessment.API
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
            
            services.AddControllers();
            services.AddSwagger();
            services.AddServices();
            services.AddDbContext(Configuration);
            services.AddAutoMapper(typeof(CustomerMappingProfile));
            services.Configure<SMSConfiguration>(Configuration.GetSection("MySmsConfig"));
            services.Configure<AlatApiConfiguration>(Configuration.GetSection("AlatTestApi"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BackendAssessmentContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendAssessment.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<ErrorHandler>();

            app.UseAuthorization();

            Seeder.Seed(dbContext).GetAwaiter().GetResult();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
