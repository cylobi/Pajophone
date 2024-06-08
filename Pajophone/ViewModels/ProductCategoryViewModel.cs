namespace Pajophone.ViewModels;

public class ProductCategoryViewModel : IViewModel
{
    public int Id { get; set; }
    public ProductCategoryViewModel? Parent { get; set; }
    public string Name { get; set; }
}