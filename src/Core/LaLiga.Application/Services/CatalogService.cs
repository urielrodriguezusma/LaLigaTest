using AutoMapper;
using LaLiga.Application.Contracts;
using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Application.Dto;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork<Product> unitOfWork;
        private readonly IMapper mapper;

        public CatalogService(IUnitOfWork<Product> unitOfWork,
                             IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            var products = await this.unitOfWork.GetRepository().GetAllAsync();
            if (products != null)
            {
                return this.mapper.Map<IReadOnlyList<ProductDto>>(products);
            }
            return null;
        }
        public async Task<IReadOnlyList<ProductDto>> GetProductsWithSpecAsync(ProductWithCategorySpecification spec)
        {
            var products = await this.unitOfWork.GetRepository().GetAllWithSpecAsync(spec);
            if (products != null)
            {
                return this.mapper.Map<IReadOnlyList<ProductDto>>(products);
            }
            return null;
        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product= await this.unitOfWork.GetRepository().GetByIdAsync(id);
            if (product != null)
            {
                var productDto = this.mapper.Map<ProductDto>(product);
                return productDto;
            }
            return null;

        }

        public async Task<ProductDto> GetProductsByIdWithSpecAsync(ProductWithCategorySpecification spec)
        {
            var product = await this.unitOfWork.GetRepository().GetByIdWithSpecAsync(spec);
            if (product != null)
            {
                return this.mapper.Map<ProductDto>(product);
            }

            return null;
        }

        public async Task<ProductDto> CreateProductAsync(ProductToCreate newProduct)
        {
            var product= this.mapper.Map<Product>(newProduct);
            var productCreated = await this.unitOfWork.GetRepository().CreateAsync(product);
            var result = this.mapper.Map<ProductDto>(productCreated);
            return result;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var productRepo = this.unitOfWork.GetRepository();
            var productToRemove= await productRepo.GetByIdAsync(id);
            if (productToRemove != null)
            {
                await productRepo.RemoveEntity(productToRemove);
                return true;
            }

            return false;
        }
        public async Task<ProductDto> UpdateProductAsync(ProductDto product)
        {
            var productToUpdate = this.mapper.Map<Product>(product);
            var updatedProduct = await this.unitOfWork.GetRepository().UpdateAsync(productToUpdate);
            var result = this.mapper.Map<ProductDto>(updatedProduct);
            return result;
        }
    }
}
