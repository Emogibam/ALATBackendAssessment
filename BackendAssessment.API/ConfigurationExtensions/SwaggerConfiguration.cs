using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BackendAssessment.API.ConfigurationExtensions
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackendAssessment.API", Version = "v1", Contact = new OpenApiContact() { 
                    Email = "eogidan22@gmail.com", 
                    Name = "Ogidan Emmanuel Bamidele" 
                } 
                });

                //var XMLFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var XMLPath = Path.Combine(AppContext.BaseDirectory, XMLFile);
                //c.IncludeXmlComments(XMLPath);
            });
        }
    }
}
