using Pajophone.Models;

namespace Pajophone.ViewModels;

public class ProductViewModel : IViewModel
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public double Price { get; set; }
    public IFormFile? Image { get; set; }
    
    public int? CategoryId { get; set; } 
    public ProductCategoryViewModel? Category { get; set; }
    public List<ProductFieldViewModel>? Fields { get; set; } = new List<ProductFieldViewModel>();
    
}