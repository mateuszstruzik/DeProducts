using AutoFixture;
using AutoMapper;
using Business.Models;
using Business.Profiles;
using Business.Services;
using Business.Services.Interfaces;
using FluentAssertions;
using Infrastructure.Clients.Interfaces;
using Moq;
using ProductDto = Infrastructure.Models.ProductDto;

namespace BussinesTest;

//Dwa przyklady testow mozna wiecej oczywiscie 
public class ProductServiceTests
{
    private readonly IProductsService _productsService;
    private readonly Mock<IFakeStoreClient> _fakeStoreClientMock = new();
    private const string TestName = "Test Name";

    public ProductServiceTests()
    {
        IFixture fixture = new Fixture();

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ProductDtoProfile());
        });
        var mapper = mappingConfig.CreateMapper();

        var productsList = fixture.CreateMany<ProductDto>().ToList();
        productsList.Add(fixture.Build<ProductDto>().With(s => s.Title, TestName).Create());

        _fakeStoreClientMock.Setup(x => x.GetProducts(default)).ReturnsAsync(productsList);
        _productsService = new ProductsService(_fakeStoreClientMock.Object, mapper);
    }

    [Fact]
    public async Task GetByFullName_SingleResultReturn()
    {
        //Arrange
        const string fullTestName = "Test Name";

        //Act
        var results = await _productsService.GetProductsByName(fullTestName, new PaginationModel(),default);

        //Assert
        results.Data.Should().HaveCount(1);
        results.Data?.SingleOrDefault()?.Title.Should().Be(TestName);
    }

    [Fact]
    public async Task GetByPartName_SingleResultReturn()
    {
        //Arrange
        const string fullTestName = "Test";

        //Act
        var results = await _productsService.GetProductsByName(fullTestName, new PaginationModel(), default);

        //Assert
        results.Data.Should().HaveCount(1);
        results.Data?.SingleOrDefault()?.Title.Should().Be(TestName);
    }
}