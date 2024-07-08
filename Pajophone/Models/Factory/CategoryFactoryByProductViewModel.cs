using Pajophone.ViewModels;
using Pajophone.Models.Builders;
namespace Pajophone.Models.Factory;

public class CategoryFactoryByProductViewModel : ICategoryFactory
{
    private ProductCategoryViewModel _viewModel;
    private ProductCategoryModel _category ;

    public void SetViewModel(ProductCategoryViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    private void SetCategory(ProductCategoryModel category)
    {
        _category = category;
    }

    public ProductCategoryModel GetCategory()
    {
        var builder = new ProductCategoryBuilder()
            .SetBasicCategory(_viewModel.Name);
        if (_viewModel.ParentId != null)
        {
            builder.SetParentCategoryId(_viewModel.ParentId.Value);
        }
        var category = builder.Build();
        
        SetCategory(category);
        return _category;
    }

    public HashSet<ProductFieldKeyModel> GetFieldKeys()
    {
        return _viewModel
            .FieldKeys
            .Select(fk => new ProductFieldKeyBuilder()
                .SetBasicField(fk.Key, fk.fieldType)
                .Build()).ToHashSet();
    }
}