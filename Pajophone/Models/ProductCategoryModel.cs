using Microsoft.EntityFrameworkCore;

namespace Pajophone.Models;

[Index(nameof(Name), IsUnique = true)]
public class ProductCategoryModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
    public ProductCategoryModel? ParentCategory { get; set; }
    
    public ICollection<ProductModel>? Products { get; set; } = new HashSet<ProductModel>();
    
    public ICollection<ProductFieldKeyModel>? FieldKeys { get; set; } = new HashSet<ProductFieldKeyModel>();
}