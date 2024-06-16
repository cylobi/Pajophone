namespace Pajophone.Models;

public class ProductFieldKeyModel : IModel
{
    public int Id { get; set; }
    public string Key { get; set; }
    public FieldType FieldType { get; set; }

    public int CategoryId { get; set; }
    public ProductCategoryModel? Category { get; set; }

    public ICollection<ProductFieldValueModel> FieldValues { get; set; } = new HashSet<ProductFieldValueModel>();
}