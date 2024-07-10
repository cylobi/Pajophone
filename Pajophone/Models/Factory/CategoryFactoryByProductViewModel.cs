using Pajophone.ViewModels;
using Pajophone.Models.Builders;
namespace Pajophone.Models.Factory;

public class CategoryFactoryByProductViewModel : ICategoryFactory
{
    private ProductCategoryViewModel _viewModel;
    private ProductCategoryModel? _category ;

    public void SetViewModel(ProductCategoryViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public ProductCategoryModel GetCategory()
    {
        var builder = new ProductCategoryBuilder()
            .SetBasicCategory(_viewModel.Name);
        if (_viewModel.ParentId != null)
            builder.SetParentCategoryId(_viewModel.ParentId.Value);
        _category = builder.Build();
        return _category;
    }

    public List<ProductFieldKeyModel> GetFieldKeys()
    {
        if (_category == null)
            throw new Exception("ERROR : CANNOT CALL GetFieldKeys() BEFORE GetCategory() ");
        return _viewModel
            .FieldKeys
            .Select(fk => new ProductFieldKeyBuilder()
                .SetBasicField(fk.Key, fk.FieldType)
                .Build()).ToList();
    }
}