
namespace Pajophone.Models;

public class ProductModel 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastEditedAt { get; set; }

    public List<ProductFieldModel> ExtraFields { set; get; }

    public int? CategoryId { get; set; }
    public ProductCategoryModel? Category { get; set; }


    public ProductModel()
    {
        Image = [];
        CreatedAt = DateTime.Now;
        LastEditedAt = DateTime.Now;
    }
}