using Pajophone.ViewModels;
using Pajophone.Models.Builders;
namespace Pajophone.Models.Factory;

public class CategoryFactoryByProductViewModel(ProductCategoryViewModel viewModel) : ICategoryFactory
{
    private readonly ProductCategoryViewModel _viewModel = viewModel;

    public ProductCategoryModel GetCategory()
    {
        var builder = new ProductCategoryBuilder()
            .SetBasicCategory(_viewModel.Name);
        if (_viewModel.ParentId != null)
        {
            builder.SetParentCategoryId(_viewModel.ParentId.Value);
        }
        return builder.Build();
    }

    public HashSet<ProductFieldKeyModel> GetFieldKeys(ProductCategoryModel category)
    {
        return _viewModel
            .FieldKeys
            .Select(fk => new ProductFieldKeyBuilder()
                .SetBasicField(fk.Key, fk.fieldType)
                .Build()).ToHashSet();
    }
}