using Pajophone.ViewModels;

namespace Pajophone.Models.Factory;

public interface IProductFactory
{
    public ProductModel GetProduct(ProductCategoryModel categoryModel);
}