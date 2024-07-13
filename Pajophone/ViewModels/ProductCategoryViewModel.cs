namespace Pajophone.ViewModels;

public class ProductCategoryViewModel : IViewModel
{
    public int? Id { get; set; }
    public int? ParentId { get; set; }
    public string Name { get; set; }
    public List<ProductFieldKeyViewModel> FieldKeys { get; set; }
}