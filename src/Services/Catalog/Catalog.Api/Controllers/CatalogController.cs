using LaLiga.Application.Contracts;
using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService catalogService;

        public CatalogController(ICatalogService catalogService)
        {
            this.catalogService = catalogService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDto),StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            ProductWithCategorySpecification productSpec = new ProductWithCategorySpecification();
            var resp = await this.catalogService.GetProductsWithSpecAsync(productSpec).ConfigureAwait(false);
            return Ok(resp);
        }
    }
}
