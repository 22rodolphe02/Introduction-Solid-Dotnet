using Microsoft.EntityFrameworkCore;
using Organic.Models.Product;

namespace Organic.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<ProduitView> ProduitViews { get; set; }
}