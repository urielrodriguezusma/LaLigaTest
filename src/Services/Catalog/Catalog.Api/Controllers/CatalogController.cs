using Catalog.Api.Errors;
using LaLiga.Application.Contracts;
using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Model;
using Microsoft.AspNetCore.JsonPatch;
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
            if (resp == null)
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
            if (resp == null)
            {
                return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            }
            return Ok(resp);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductToCreate newProduct)
        {
            var product = await this.catalogService.CreateProductAsync(newProduct).ConfigureAwait(false);
            return Ok(product);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromRoute]int id, [FromBody] JsonPatchDocument<ProductDto> pathProduct)
        {
            if (pathProduct == null)
            {
                return BadRequest(new ApiResponse(StatusCodes.Status400BadRequest));
            }
            ProductWithCategorySpecification productSpec = new ProductWithCategorySpecification(id);
            var product = await this.catalogService.GetProductsByIdWithSpecAsync(productSpec);
            if (product == null)
            {
                return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
            }

            pathProduct.ApplyTo(product,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }

            var productUpdated = await this.catalogService.UpdateProductAsync(product);
            return Ok(productUpdated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var productDeleted = await this.catalogService.DeleteProductByIdAsync(id).ConfigureAwait(false);
            if (productDeleted)
                return NoContent();

            return NotFound(new ApiResponse(StatusCodes.Status404NotFound));
        }

    }
}
