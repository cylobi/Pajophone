using Pajophone.Models.Builders;
using Pajophone.ViewModels;

namespace Pajophone.Models.Factory;

public class ProductFactoryByProductViewModel(ProductViewModel viewModel) : IProductFactory
{
    private readonly ProductViewModel _viewModel = viewModel;
    
    public ProductModel GetProduct()
    {
        var builder = new ProductBuilder()
            .SetBasicProduct(_viewModel.Name, _viewModel.Description, _viewModel.Color)
            .AddPrice(_viewModel.Price);
        if (_viewModel.Image != null)
        {
            builder.AddImage(_viewModel.Image);
        }

        if (_viewModel.Category is { Id: not null })
        {
            builder.SetCategoryId(_viewModel.Category.Id.Value);
        }
        return builder
            .Build();
    }

    public ICollection<ProductFieldValueModel> GetFieldValues(ProductModel product)
    {
        if (_viewModel.Fields.All(f => f.KeyId.HasValue) == false)
        {
            throw new Exception();
        }
        
        return _viewModel.Fields?.Select(f => new ProductFieldValueBuilder()
            .SetBasicField(f.KeyId.Value, f.Value)
            .SetProduct(product)
            .Build()).ToList();
    }
}