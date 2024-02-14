using AutoMapper;
using Business.Models;

namespace Business.Profiles;
using Infra = Infrastructure.Models;

internal class ProductDtoProfile : Profile
{
    public ProductDtoProfile()
    {
        CreateMap<Infra.ProductDto, ProductDto>();
        CreateMap<Infra.RatingDto, RatingDto>();
    }
}