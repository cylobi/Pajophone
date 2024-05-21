
namespace Pajophone.Models;

public class ProductModel : IBaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public byte[] Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastEditedAt { get; set; }

    public List<ProductFieldModel> ExtraFields { set; get; }


    public ProductModel()
    {
        Image = [];
    }
}