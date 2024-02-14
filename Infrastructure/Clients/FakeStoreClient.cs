using System.Text.Json;
using Infrastructure.Clients.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Clients;

internal class FakeStoreClient(IHttpClientFactory httpClientFactory) : IFakeStoreClient
{
    private const string ProductsPath = "products/";
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(nameof(FakeStoreClient));

    public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken ct)
    {
        var response = await _httpClient.GetAsync($"{ProductsPath}", ct);

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<ProductDto>();
        }

        var stream = await response.Content.ReadAsStreamAsync(ct);

        return await JsonSerializer.DeserializeAsync<ProductDto[]>(stream, cancellationToken: ct) ?? Enumerable.Empty<ProductDto>();
    }
}