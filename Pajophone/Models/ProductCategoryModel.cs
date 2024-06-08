using Microsoft.EntityFrameworkCore;

namespace Pajophone.Models;

[Index(nameof(Name), IsUnique = true)]
public class ProductCategoryModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
    public ProductCategoryModel? ParentCategory { get; set; }

    public ICollection<int> ProductsId { get; set; } = new HashSet<int>();
    public ICollection<ProductModel>? Products { get; set; } = new HashSet<ProductModel>();

    public ICollection<int> FieldKeysId { get; set; } = new HashSet<int>();
    public ICollection<ProductFieldKeyModel>? FieldKeys { get; set; } = new HashSet<ProductFieldKeyModel>();
}