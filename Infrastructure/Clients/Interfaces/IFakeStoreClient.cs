using Infrastructure.Models;

namespace Infrastructure.Clients.Interfaces;

public interface IFakeStoreClient
{
    Task<IEnumerable<ProductDto>> GetProducts(CancellationToken ct);
}