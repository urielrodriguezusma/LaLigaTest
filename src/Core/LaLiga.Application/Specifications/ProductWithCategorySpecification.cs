using LaLiga.Domain.Model;

namespace LaLiga.Application.Specifications
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(int id) : base(d => d.Id == id)
        {
            this.AddInclude(d => d.Category);
        }
        public ProductWithCategorySpecification()
        {
            this.AddInclude(d => d.Category);
        }
    }
}
