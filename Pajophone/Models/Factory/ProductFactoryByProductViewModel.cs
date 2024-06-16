using Pajophone.Models.Builders;
using Pajophone.ViewModels;

namespace Pajophone.Models.Factory;

public class ProductFactoryByProductViewModel(ProductViewModel viewModel) : IProductFactory
{
    private readonly ProductViewModel _viewModel = viewModel;
    
    public ProductModel GetProduct(ProductCategoryModel categoryModel)
    {
        var builder = new ProductBuilder()
            .SetBasicProduct(_viewModel.Name, _viewModel.Description, _viewModel.Color)
            .AddPrice(_viewModel.Price);
        if (_viewModel.Image != null)
        {
            builder.AddImage(_viewModel.Image);
        }
        return builder
            .SetCategory(categoryModel)
            .Build();
    }
}