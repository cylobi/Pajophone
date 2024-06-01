namespace Pajophone.Models;

public class ProductFieldModel : IModel
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public int ProductId { get; set; }
    public ProductModel Product { get; set; } = null!;
}