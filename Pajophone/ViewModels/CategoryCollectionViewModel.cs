namespace Pajophone.ViewModels;

public class CategoryCollectionViewModel : IViewModel
{
    public ICollection<ProductCategoryViewModel> Categories = new HashSet<ProductCategoryViewModel>();
}