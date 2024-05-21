using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace Pajophone.Models;

public class ProductModel : IBaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string ImageUrl { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastEditedAt { get; set; }

    public ICollection<ProductFieldModel> ExtraFields { set; get; } = new List<ProductFieldModel>();

}