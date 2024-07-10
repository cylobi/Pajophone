using Pajophone.Models.Builders;
using Pajophone.ViewModels;

namespace Pajophone.Models.Factory;

public class ProductFactoryByProductViewModel : IProductFactory
{
    private ProductViewModel _viewModel;
    private ProductModel _product;

    public void SetViewModel(ProductViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    
    public ProductModel GetProduct()
    {
        var builder = new ProductBuilder()
            .SetBasicProduct(_viewModel.Name, _viewModel.Description, _viewModel.Color)
            .AddPrice(_viewModel.Price);
        if (_viewModel.Image != null)
            builder.AddImage(_viewModel.Image);
        if (_viewModel.CategoryId == null)
            throw new Exception("ERROR: Category ID CANNOT BE EMPTY"); 
        builder.SetCategoryId(_viewModel.CategoryId.Value);
        _product = builder.Build();
        return _product;
    }

    public List<ProductFieldValueModel> GetFieldValues()
    {
        if (_product == null)
            throw new Exception("ERROR : CANNOT CALL GetFieldValues() BEFORE GetProduct() ");
        
        if (_viewModel.Fields.All(f => f.KeyId.HasValue))
            throw new Exception();
        
        return _viewModel.Fields?.Select(f => new ProductFieldValueBuilder()
            .SetBasicField(f.KeyId.Value, f.Value)
            .SetProduct(_product)
            .Build()).ToList();
    }
}