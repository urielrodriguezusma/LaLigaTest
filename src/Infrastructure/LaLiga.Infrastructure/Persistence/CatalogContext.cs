using LaLiga.Domain.Model;
using LaLiga.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LaLiga.Infrastructure.Persistence
{
    public class CatalogContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public CatalogContext(DbContextOptions<CatalogContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
             {
                    new Category {Id=1, CategoryName="Technology",Description="Everything in technology"},
                    new Category {Id=2, CategoryName="T-Shirts",Description="Fashion for all teams"},
                    new Category {Id=3,CategoryName="Hoodie",Description="Hoodie relaxing fit XCH"}
             });
            modelBuilder.Entity<Product>().HasData(new Product[]
            {    new Product
                 {
                     Id=1,
                     Name= "Apple Watch",
                     CategoryId=1,
                     Stock=60,
                     UnitPrice= 1600000
                 },
                 new Product
                 {
                     Id=2,
                     Name= "Madrid T-Shirt",
                     Stock=140,
                     CategoryId=2,
                     UnitPrice= 600000
                 },
                 new Product
                 {
                     Id = 3,
                     Name= "Looney Toons",
                     Stock=50,
                     CategoryId=3,
                     UnitPrice= 120000
                 },
                  new Product
                 {
                     Id = 4,
                     Name= "IPhone 12",
                     Stock=80,
                     CategoryId=1,
                     UnitPrice= 3400000
                 }
            });          
            
            modelBuilder.ApplyConfiguration(new ProductConfiguration())
                        .ApplyConfiguration(new CategoryConfiguration());

        }
    }
}
