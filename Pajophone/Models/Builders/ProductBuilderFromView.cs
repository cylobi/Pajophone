using Pajophone.ViewModels;

namespace Pajophone.Models.Builder;

public class ProductBuilderFromView : ProductBuilder
{
    public ProductBuilderFromView(ProductViewModel productModelView)
        : base()
    {
        BuildBasicProduct(productModelView.Name, productModelView.Description, productModelView.Color);
    }
        
}