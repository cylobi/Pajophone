namespace Pajophone.Models;

public class ProductFieldModel
{
    public string key { get; set; }
    public string value { get; set; }
    public int ProductModelId { get; set; }
    public ProductModel Product { get; set; } = null!;
}