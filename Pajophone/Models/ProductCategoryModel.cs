namespace Pajophone.Models;

public class ProductCategoryModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? ParentCategoryId { get; set; }
    public ProductCategoryModel? ParentCategory { get; set; }
    
}