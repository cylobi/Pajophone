using Pajophone.ViewModels;

namespace Pajophone.Models.Builders;

public class ProductBuilderFromView : ProductBuilder
{
    public ProductBuilderFromView()
        : base()
    {
    }
    public ProductBuilder SetBasicProduct(ProductViewModel productViewModel)
    {
        return SetBasicProduct(productViewModel.Name, productViewModel.Description, productViewModel.Color)
            .AddImage(productViewModel.Image);
    }
}