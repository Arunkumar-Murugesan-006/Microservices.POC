using Microsoft.EntityFrameworkCore;
using Product.Service.Models;

namespace Product.Service.Data.DB_Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductModel> Products { get; set; }
    }
}
