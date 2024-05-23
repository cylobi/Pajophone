namespace Pajophone.Models;

public class ProductCategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? ParentCategoryId { get; set; }
    public ProductCategoryModel? ParentCategory { get; set; }
    
}