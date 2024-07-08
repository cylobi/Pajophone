using Pajophone.ViewModels;
namespace Pajophone.Models.Factory;

public interface ICategoryFactory
{
    public void SetViewModel(ProductCategoryViewModel viewModel);
    public ProductCategoryModel GetCategory();

    public HashSet<ProductFieldKeyModel> GetFieldKeys();
}