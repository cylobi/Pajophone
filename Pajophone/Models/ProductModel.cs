
namespace Pajophone.Models;

public class ProductModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public byte[]? Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastEditedAt { get; set; }

    public ICollection<int> FieldvaluesId { get; set; } = new HashSet<int>();
    public ICollection<ProductFieldValueModel>? FieldValues { set; get; } = new HashSet<ProductFieldValueModel>();

    public ProductModel()
    {
        Image = [];
        CreatedAt = DateTime.Now;
        LastEditedAt = DateTime.Now;
    }
}