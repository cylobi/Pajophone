using Pajophone.Models;

namespace Pajophone.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public IFormFile Image { get; set; }

    public List<ProductFieldViewModel>? Fields { set; get; }
    public List<ProductCategoryModel>? Categories { set; get; }
}