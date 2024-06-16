using Pajophone.Data.Contexts;
using Pajophone.Models;
using Pajophone.Models.Builders;

namespace Pajophone.Data;

public static class DataSeeder
{

    public static void SeedData(this ApplicationContext context)
    {
        if (context.ProductCategories.Any())
        {
            return;
        }
        var categories = context.GetSeededProductCategories();
        var fieldKeys = context.GetSeededProductFieldKeys(categories);
        var products = context.GetSeededProducts(categories);
        var fieldValues = context.GetSeededProductFieldValues(products, fieldKeys);
        context.Set<ProductCategoryModel>().AddRange(categories);
        context.Set<ProductFieldKeyModel>().AddRange(fieldKeys);
        context.Set<ProductModel>().AddRange(products);
        context.Set<ProductFieldValueModel>().AddRange(fieldValues);
        context.SaveChanges();
    }
    public static List<ProductCategoryModel> GetSeededProductCategories(this ApplicationContext context)
    {
        var categoriesName = new List<string>(){"All", "Smartphones", "smartwatch"};
        ProductCategoryModel root = new ProductCategoryBuilder()
            .SetBasicCategory(categoriesName.First())
            .Build();
        
        var categories = categoriesName
            .Skip(1)
            .Select(name => new ProductCategoryBuilder()
                .SetBasicCategory(name)
                .SetParentCategory(root)
                .Build())
            .ToList();
        return categories;
    }

    private record ProductDetail(string Name, string Desc, string Color, string CategoryName);
    public static List<ProductModel> GetSeededProducts(this ApplicationContext context, List<ProductCategoryModel> categories)
    {
        var productsDetail = new List<ProductDetail>()
        {
            new ProductDetail("pajoPhone 1", "PajoPhone 1", "White", "Smartphones"),
            new ProductDetail("pajoPhone 2", "PajoPhone 2", "White", "Smartphones"),
            new ProductDetail("pajoPhone 2 Elite", "PajoPhone 2 Elite", "Black", "Smartphones"),
            new ProductDetail("PajoWatch 1", "PajoWatch 1", "White", "smartwatch"),
            new ProductDetail("PajoWear 2", "PajoWear 2", "White", "smartwatch"),
            new ProductDetail("PajoWear Tomato-e-Javanan", "PajoPhone 2 Tomato-e-Javanan", "White", "smartwatch")
        };
        var products = productsDetail
            .Select(detail => new ProductBuilder()
                .SetBasicProduct(detail.Name, detail.Desc, detail.Color)
                .SetCategory(categories.First(c => c.Name == detail.CategoryName))
                .Build())
            .ToList(); 
        
        return products;
    }

    private record FieldKeyDetail(string Name, FieldType FType, string CategoryName);
    public static List<ProductFieldKeyModel> GetSeededProductFieldKeys(this ApplicationContext context,
        List<ProductCategoryModel> categories)
    {
        var fieldKeyDetails = new List<FieldKeyDetail>()
        {
            new FieldKeyDetail("CPU", FieldType.String, "Smartphones"),
            new FieldKeyDetail("OS", FieldType.String, "Smartphones"),
            new FieldKeyDetail("RAM", FieldType.Range, "Smartphones"),
            new FieldKeyDetail("Screen Size", FieldType.Range, "Smartphones"),
            new FieldKeyDetail("Battery", FieldType.Range, "smartwatch"),
            new FieldKeyDetail("Weight", FieldType.Range, "smartwatch"),
            new FieldKeyDetail("Water Resistance", FieldType.Bool, "smartwatch")
        };
        
        var fieldKeys = fieldKeyDetails
            .Select(detail => new ProductFieldKeyBuilder()
                .SetBasicField(detail.Name, detail.FType)
                .SetCategory(categories.First(c => c.Name == detail.CategoryName))
                .Build())
            .ToList();
        
        return fieldKeys;
    }
    
    private record FieldValueDetail(string Value, string FieldKeyName, string ProductName);
    public static List<ProductFieldValueModel> GetSeededProductFieldValues(this ApplicationContext context,
        List<ProductModel> products, List<ProductFieldKeyModel> fieldKeys)
    {
        var fieldValueDetails = new List<FieldValueDetail>()
        {
            new FieldValueDetail("Pejodragon X","CPU","pajoPhone 1"),
            new FieldValueDetail("Pejos","OS","pajoPhone 1"),
            new FieldValueDetail("6GB","RAM","pajoPhone 1" ),
            new FieldValueDetail("6.2Inch","Screen Size","pajoPhone 1"),
            new FieldValueDetail("Pejodragon X plus","CPU","pajoPhone 2"),
            new FieldValueDetail("Pejos","OS","pajoPhone 2"),
            new FieldValueDetail("8GB","RAM","pajoPhone 2"),
            new FieldValueDetail("6.5Inch","Screen Size","pajoPhone 2"),
            new FieldValueDetail("Pejodragon X Elite","CPU","pajoPhone 2 Elite"),
            new FieldValueDetail("Pejos","OS","pajoPhone 2 Elite"),
            new FieldValueDetail("10GB","RAM","pajoPhone 2 Elite"),
            new FieldValueDetail("6.5Inch","Screen Size","pajoPhone 2 Elite"),
            new FieldValueDetail("30mAh","Battery", "PajoWatch 1"),
            new FieldValueDetail("500g","Weight", "PajoWatch 1"),
            new FieldValueDetail("N","Water Resistance", "PajoWatch 1"),
            new FieldValueDetail("50mAh","Battery", "PajoWear 2"),
            new FieldValueDetail("450g","Weight", "PajoWear 2"),
            new FieldValueDetail("Y","Water Resistance", "PajoWear 2"),
            new FieldValueDetail("700mAh","Battery", "PajoWear Tomato-e-Javanan"),
            new FieldValueDetail("600g","Weight", "PajoWear Tomato-e-Javanan"),
            new FieldValueDetail("N","Water Resistance", "PajoWear Tomato-e-Javanan")
        };
        var fieldValues = fieldValueDetails
            .Select(detail => new ProductFieldValueBuilder()
                .SetBasicField(detail.Value)
                .SetProduct(products.First(c => c.Name == detail.ProductName))
                .SetFieldKey(fieldKeys.First(c => c.Key == detail.FieldKeyName))
                .Build())
            .ToList();
        
        return fieldValues;
    }
}