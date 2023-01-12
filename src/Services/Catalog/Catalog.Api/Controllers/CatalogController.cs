using Catalog.Api.Errors;
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
        [ProducesResponseType(typeof(IReadOnlyList<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            ProductWithCategorySpecification productSpec = new ProductWithCategorySpecification();
            var resp = await this.catalogService.GetProductsWithSpecAsync(productSpec).ConfigureAwait(false);
            if(resp == null)
            {
                return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            }
            return Ok(resp);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            ProductWithCategorySpecification productSpec = new ProductWithCategorySpecification(id);
            var resp = await this.catalogService.GetProductsByIdWithSpecAsync(productSpec).ConfigureAwait(false);
            return Ok(resp);
        }

    }
}
