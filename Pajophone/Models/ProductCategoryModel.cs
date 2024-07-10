using Microsoft.EntityFrameworkCore;

namespace Pajophone.Models;

[Index(nameof(Name), IsUnique = true)]
public class ProductCategoryModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
    public ProductCategoryModel? ParentCategory { get; set; }
    
    public List<ProductModel>? Products { get; set; } = new List<ProductModel>();
    
    public List<ProductFieldKeyModel>? FieldKeys { get; set; } = new List<ProductFieldKeyModel>();
}