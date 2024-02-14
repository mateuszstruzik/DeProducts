using Infrastructure.Clients.Interfaces;
using Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Clients
{
    public class FakeStoreClientCache(IFakeStoreClient fakeStoreClient, IMemoryCache memoryCache) : IFakeStoreClient
    {
        private const int ExpirationTimeInSeconds = 300;
        private const string Key = "key";
        public async Task<IEnumerable<ProductDto>> GetProducts(CancellationToken ct)
        {
            var existingResults = memoryCache.Get<List<ProductDto>>(Key);

            if (existingResults != null)
            {
                return existingResults;
            }

            var results = (await fakeStoreClient.GetProducts(ct)).ToList();
            memoryCache.Set(Key, results, new TimeSpan(0,0, ExpirationTimeInSeconds));

            return results;
        }
    }
}
