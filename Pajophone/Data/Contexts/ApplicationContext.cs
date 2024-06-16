using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Pajophone.Models;
using Pajophone.Models.Builders;

namespace Pajophone.Data.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ProductFieldKeyModel> ProductFieldKeys { get; set; }
    public DbSet<ProductFieldValueModel> ProductFieldValues { get; set; }
    public DbSet<ProductCategoryModel> ProductCategories { get; set; }
}