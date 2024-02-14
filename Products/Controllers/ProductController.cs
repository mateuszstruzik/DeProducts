using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers;

//NIe dodalem autoryzacji ale mozna by naprzyklad zrobic jedna z prostszych typu api key w hederze albo basic 
[ApiController]
[Route("[controller]")]
public class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet("Category")]
    [ProducesResponseType(typeof(PaginationResultModel<IReadOnlyList<ProductDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // Mozna dodac jeszcze dodatkowe opisy do swaggera 
    public async Task<IActionResult> GetByCategory([FromQuery] string[] categories, [FromQuery] PaginationModel pagination, CancellationToken ct)
    {
        //try catch nie jest pewnie idealny mozna by od razu zrwacac Actionresulty z serwisow albo daodc global hendler dla exceptionow
        try
        {
            var results = await productsService.GetProductsByCategories(categories, pagination, ct);

            return Ok(results);
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpGet("Name/{name}")]
    [ProducesResponseType(typeof(PaginationResultModel<IReadOnlyList<ProductDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByName(string name, [FromQuery] PaginationModel pagination, CancellationToken ct)
    {
        try
        {
            var results = await productsService.GetProductsByName(name, pagination, ct);
            return Ok(results);
        }
        catch
        {
            return BadRequest();
        }
    }
}