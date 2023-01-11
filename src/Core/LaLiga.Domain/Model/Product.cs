using LaLiga.Domain.Common;

namespace LaLiga.Domain.Model
{
    public class Product : BaseDomainModel
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
