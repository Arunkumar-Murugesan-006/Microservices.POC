using Microsoft.EntityFrameworkCore;
using Quote.Service.Models;

namespace Quote.Service.Data.DB_Context
{
    public class QuoteDbContext : DbContext
    {
        public QuoteDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<QuoteModel> Quotes { get; set; }
    }
}
