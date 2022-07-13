using BackendAssessment.Core.Services.Implimentations;
using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Infrastructure.Repository.Implimentation;
using BackendAssessment.Infrastructure.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BackendAssessment.API.ConfigurationExtensions
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerServices, CustomerServices>()
              .AddScoped<ILGAServices, LGAServices>()
              .AddScoped<ISendOTPSms, SendOTPSms>()
              .AddScoped<ICustomerRepository, CustomerRepository>()
              .AddScoped<IBankServices, BankServices>();
        }
    }
}
