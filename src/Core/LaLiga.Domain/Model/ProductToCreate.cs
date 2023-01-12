namespace LaLiga.Domain.Model
{
    public class ProductToCreate
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}
