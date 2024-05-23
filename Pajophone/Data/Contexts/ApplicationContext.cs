using Microsoft.EntityFrameworkCore;
using Pajophone.Models;
namespace Pajophone.Data.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    public DbSet<ProductModel> Products { get; set; } = null!;
    public DbSet<ProductFieldModel> ProductFields { get; set; } = null!;
    public DbSet<ProductCategoryModel> ProductCategories { get; set; } = null!;
}