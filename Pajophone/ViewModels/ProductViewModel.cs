using Pajophone.Models;

namespace Pajophone.ViewModels;

public class ProductViewModel : IViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public IFormFile? Image { get; set; }

    public ProductCategoryViewModel? Category { get; set; }
    public ICollection<ProductFieldViewModel>? Fields { get; set; } = new HashSet<ProductFieldViewModel>();
}