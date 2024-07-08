using Pajophone.ViewModels;

namespace Pajophone.Models.Factory;

public interface IProductFactory
{
    public ProductModel GetProduct();
    public ICollection<ProductFieldValueModel> GetFieldValues(ProductModel product);
}