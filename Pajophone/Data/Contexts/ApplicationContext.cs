using Microsoft.EntityFrameworkCore;
using Pajophone.Models;
using Pajophone.Models.Builders;

namespace Pajophone.Data.Contexts;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductFieldKeyModel>().HasData(
            new ProductFieldKeyBuilder().SetBasicField(1, "CPU", FieldType.String).Build(),
            new ProductFieldKeyBuilder().SetBasicField(2, "OS", FieldType.String).Build(),
            new ProductFieldKeyBuilder().SetBasicField(3, "RAM", FieldType.Range).Build(),
            new ProductFieldKeyBuilder().SetBasicField(4, "Screen Size", FieldType.Range).Build(),
            new ProductFieldKeyBuilder().SetBasicField(5, "Battery", FieldType.Range).Build(),
            new ProductFieldKeyBuilder().SetBasicField(6, "Weight", FieldType.Range).Build(),
            new ProductFieldKeyBuilder().SetBasicField(7, "Water Resistance", FieldType.Bool).Build()
        );
        
        modelBuilder.Entity<ProductFieldValueModel>().HasData(
            new ProductFieldValueBuilder()
                .SetBasicField(1,1, "Pejodragon X")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(2, 2, "Pejos")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(3,3, "6GB")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(4, 4, "6.2Inch")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(5, 1, "Pejodragon X plus")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(6,2, "Pejos")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(7,3, "8GB")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(8,4, "6.5Inch")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(9,1, "Pejodragon X Elite")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(10,2, "Pejos")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(11,3, "10GB")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(12,4, "6.5Inch")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(13,5, "30mAh")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(14,6, "500g")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(15,7, "N")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(16,5, "50mAh")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(17,6, "450g")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(18,7, "Y")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(19,5, "700mAh")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(20,6, "600g")
                .Build(),
            new ProductFieldValueBuilder()
                .SetBasicField(21,7, "N")
                .Build()
        );
        
        modelBuilder.Entity<ProductModel>().HasData(
            new ProductBuilder()
                .SetId(1)
                .SetBasicProduct("PajoPhone 1", "PajoPhone 1", "White")
                .AddFieldValuesId([1, 2, 3, 4])
                .Build(),
            new ProductBuilder()
                .SetId(2)
                .SetBasicProduct("PajoPhone 2", "PajoPhone 2", "White")
                .AddFieldValuesId([5, 6, 7, 8])
                .Build(),
            new ProductBuilder()
                .SetId(3)
                .SetBasicProduct("PajoPhone 2 Elite", "PajoPhone 2 Elite - 5.5G", "Black")
                .AddFieldValuesId([9, 10, 11, 12])
                .Build(),
            new ProductBuilder()
                .SetId(4)
                .SetBasicProduct("PajoWatch 1", "PajoWatch 1", "White")
                .AddFieldValuesId([13, 14, 15, 16])
                .Build(),
            new ProductBuilder()
                .SetId(5)
                .SetBasicProduct("PajoWear 2", "PajoWear 2", "White")
                .AddFieldValuesId([16, 17, 18])
                .Build(),
            new ProductBuilder()
                .SetId(6)
                .SetBasicProduct("PajoWear Tomato-e-Javanan", "PajoPhone 2 Tomato-e-Javanan", "White")
                .AddFieldValuesId([19, 20, 21])
                .Build()
        );
        
        modelBuilder.Entity<ProductCategoryModel>().HasData(
            new ProductCategoryBuilder()
                .SetBasicCategory(1, "All")
                .Build()
            ,
            new ProductCategoryBuilder()
                .SetBasicCategory(2,"Electronic Devices")
                .SetParentCategoryId(1)
                .Build()
            ,
            new ProductCategoryBuilder()
                .SetBasicCategory(3, "Smartphones")
                .SetParentCategoryId(2)
                .AddFieldKeysId([1,2,3,4])
                .AddProductsId([1,2,3])
                .Build(),
            new ProductCategoryBuilder()
                .SetBasicCategory(4,"smartwatch")
                .SetParentCategoryId(2)
                .AddFieldKeysId([5,6,7])
                .AddProductsId([4,5,6])
                .Build()
        );
    }

    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ProductFieldKeyModel> ProductFieldKeys { get; set; }
    public DbSet<ProductFieldValueModel> ProductFieldValues { get; set; }
    public DbSet<ProductCategoryModel> ProductCategories { get; set; }
    
}