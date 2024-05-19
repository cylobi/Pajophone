using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace Pajophone.Models;

public class ProductModel : BaseModel
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string ImageUrl { get; set; }
}