namespace Pajophone.ViewModels;

public class ProductCollectionViewModel : IViewModel
{
    public ICollection<ProductViewModel> ProductCollection = new HashSet<ProductViewModel>();
}