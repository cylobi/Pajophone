namespace Pajophone.Models;

public class ProductFieldModel
{
    public int Id { get; set; }
    public string key { get; set; }
    public string value { get; set; }
    public int ProductId { get; set; }
    public ProductModel Product { get; set; } = null!;
}