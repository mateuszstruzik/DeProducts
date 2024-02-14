using Business.Services;
using Business.Services.Interfaces;
using Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddBusinessScoped(this IServiceCollection services, IConfiguration configuration) => 
            services.AddScoped<IProductsService, ProductsService>()
                .AddClientsScoped(configuration)
                .AddAutoMapper(typeof(IoCExtensions).Assembly)
            ;
    }
}
