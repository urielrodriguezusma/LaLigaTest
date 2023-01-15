using AutoMapper;
using LaLiga.Application.Contracts;
using LaLiga.Application.Contracts.Infrastructure;
using LaLiga.Application.Dto;
using LaLiga.Application.Helpers;
using LaLiga.Application.Specifications;
using LaLiga.Domain.Common;
using LaLiga.Domain.Model;

namespace LaLiga.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CatalogService(IUnitOfWork unitOfWork,
                             IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<PagedList<ProductDto>> GetProductsAsync(UserParams userParams)
        {
            var pagedList = await this.unitOfWork.GetRepository<Product>().GetAllAsync(userParams);

            if (pagedList != null)
            {
                return this.mapper.Map<PagedList<ProductDto>>(pagedList);
            }
            return null;
        }
        public async Task<PagedList<ProductDto>> GetProductsWithSpecAsync(UserParams userParams, ProductWithCategorySpecification spec)
        {
            var pagedList = await this.unitOfWork.GetRepository<Product>().GetAllWithSpecAsync(userParams, spec);
            if (pagedList != null)
            { 

                var  = this.mapper.Map<List<ProductDto>>(pagedList);
                var lstProductsDto = this.mapper.Map<List<ProductDto>>(pagedList);
                return new PagedList<ProductDto>(lstProductsDto, 
                                                 pagedList.PaginationHeader.TotalCount, 
                                                 pagedList.PaginationHeader.CurrentPage, 
                                                 pagedList.PaginationHeader.PageSize);
            }
            return null;
        }
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await this.unitOfWork.GetRepository<Product>().GetByIdAsync(id);
            if (product != null)
            {
                var productDto = this.mapper.Map<ProductDto>(product);
                return productDto;
            }
            return null;

        }

        public async Task<ProductDto> GetProductsByIdWithSpecAsync(ProductWithCategorySpecification spec)
        {
            var product = await this.unitOfWork.GetRepository<Product>().GetByIdWithSpecAsync(spec);
            if (product != null)
            {
                return this.mapper.Map<ProductDto>(product);
            }

            return null;
        }

        public async Task<ProductDto> CreateProductAsync(ProductToCreate newProduct)
        {
            var product = this.mapper.Map<Product>(newProduct);
            var productCreated = await this.unitOfWork.GetRepository<Product>().CreateAsync(product);
            var result = this.mapper.Map<ProductDto>(productCreated);
            return result;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var productRepo = this.unitOfWork.GetRepository<Product>();
            var productToRemove = await productRepo.GetByIdAsync(id);
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
            var updatedProduct = await this.unitOfWork.GetRepository<Product>().UpdateAsync(productToUpdate);
            var result = this.mapper.Map<ProductDto>(updatedProduct);
            return result;
        }
    }
}
