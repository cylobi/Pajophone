namespace Pajophone.Models;

public class ProductFieldValueModel : IModel
{
    public int Id { get; set; }
    public string Value { get; set; }

    public int FieldKeyId { get; set; }
    public ProductFieldKeyModel? FieldKey { get; set; }
}