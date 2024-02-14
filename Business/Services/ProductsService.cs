using AutoMapper;
using Business.Models;
using Business.Services.Interfaces;
using Infrastructure.Clients.Interfaces;

namespace Business.Services;

internal class ProductsService(IFakeStoreClient fakeStoreClient, IMapper mapper) : IProductsService
{
    //Paginacja jest dosyc prosto zrobiona, niestety powinna byc tez nalozona na call to fake store ale tam nie ma mozliwosci ziwkeszanai pagy 
    //Tylko limitów. Model PaginationResultModel mozna rozbudowac o liczbe wszystkich stron, wszystkich rekordów,itd.. wtedy mozna
    //zaimplementowac dodatkowa logike do srpawdzania czy dany call ma jeszcze sens 
    public async Task<PaginationResultModel<IReadOnlyList<ProductDto>>> GetProductsByCategories(string[] categories, PaginationModel pagination, CancellationToken ct)
    {
        var results = (await fakeStoreClient.GetProducts(ct))
            .Where(w => categories.Contains(w.Category))
            .Skip(pagination.GetSkip())
            .Take(pagination.Take)
            .ToList();

        return new PaginationResultModel<IReadOnlyList<ProductDto>>
        {
            Page = pagination.Page,
            Size = pagination.Take,
            Data = mapper.Map<IReadOnlyList<ProductDto>>(results)
        };
    }

    public async Task<PaginationResultModel<IReadOnlyList<ProductDto>>> GetProductsByName(string name, PaginationModel pagination, CancellationToken ct)
    {
        var results = (await fakeStoreClient.GetProducts(ct))
            .Where(w => w.Title.Contains(name, StringComparison.InvariantCulture))
            .Skip(pagination.GetSkip())
            .Take(pagination.Take)
            .ToList();

        return new PaginationResultModel<IReadOnlyList<ProductDto>>
        {
            Page = pagination.Page,
            Size = pagination.Take,
            Data = mapper.Map<IReadOnlyList<ProductDto>>(results)
        };
    }
}