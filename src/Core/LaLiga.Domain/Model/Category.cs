using LaLiga.Domain.Common;

namespace LaLiga.Domain.Model
{
    public class Category : BaseDomainModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
