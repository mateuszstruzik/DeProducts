using System.Net.Http.Headers;
using System.Net.Mime;
using Infrastructure.Clients;
using Infrastructure.Clients.Interfaces;
using Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.Extensions
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddClientsScoped(this IServiceCollection services, IConfiguration configuration) =>
            services.RegisterFakeStoreClient(configuration)
                .AddMemoryCache();

        private static IServiceCollection RegisterFakeStoreClient(this IServiceCollection services, IConfiguration configuration)
        {
            var fakeStoreClientConfiguration = configuration.GetSection(FakeStoreClientConfigurationModel.SectionName).Get<FakeStoreClientConfigurationModel>();

            services.AddHttpClient(nameof(FakeStoreClient), client =>
            {
                client.BaseAddress = new Uri(fakeStoreClientConfiguration?.BaseAddress ?? string.Empty);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            });

            return services.AddScoped<IFakeStoreClient, FakeStoreClient>()
                .Decorate<IFakeStoreClient, FakeStoreClientCache>();
        }
    }
}
