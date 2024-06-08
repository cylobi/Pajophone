namespace Pajophone.Models;

public class ProductFieldKeyModel : IModel
{
    public int Id { get; set; }
    public string Key { get; set; }
    public FieldType FieldType { get; set; }
}