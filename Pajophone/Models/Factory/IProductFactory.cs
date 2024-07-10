using Pajophone.ViewModels;

namespace Pajophone.Models.Factory;

public interface IProductFactory
{
    public void SetViewModel(ProductViewModel viewModel);
    public ProductModel GetProduct();
    public List<ProductFieldValueModel> GetFieldValues();
}