using FluentValidation;
using LaLiga.Domain.Model;

namespace Catalog.Api.Validators
{
    public class ProductToCreateValidator:AbstractValidator<ProductToCreate>
    {
        public ProductToCreateValidator()
        {
            RuleFor(d => d.ProductName).NotEmpty()
                                       .WithMessage("Product name is required")
                                       .MaximumLength(30)
                                       .WithMessage("Product name should have max 30 characters");

            RuleFor(d => d.CategoryId).NotNull()
                                      .WithMessage("CategoryId is required")
                                      .InclusiveBetween(1, 3)
                                      .WithMessage("CategoryId should be a number between 1 - 3");

            RuleFor(d => d.Stock).NotEmpty()
                                 .GreaterThanOrEqualTo(0)
                                 .WithMessage("Stock should be a value greater or equals to zero");
                   
        }
    }
}
