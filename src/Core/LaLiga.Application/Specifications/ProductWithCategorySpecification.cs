using LaLiga.Domain.Model;

namespace LaLiga.Application.Specifications
{
    public class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification(int id) : base(d => d.Id == id)
        {
            AddProductInclude();
        }
        public ProductWithCategorySpecification()
        {
            AddProductInclude();
        }

        private void AddProductInclude()
        {
            this.AddInclude(d => d.Category);
        }
    }
}
