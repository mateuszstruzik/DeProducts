using Business.Models;

namespace Business.Services.Interfaces
{
    public interface IProductsService
    {
        public Task<PaginationResultModel<IReadOnlyList<ProductDto>>> GetProductsByCategories(string[] categories, PaginationModel pagination, CancellationToken ct);

        public Task<PaginationResultModel<IReadOnlyList<ProductDto>>> GetProductsByName(string name, PaginationModel pagination, CancellationToken ct);
    }
}
