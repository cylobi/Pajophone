using NuGet.Configuration;
using NuGet.Packaging;

namespace Pajophone.Models.Builders;

public class ProductCategoryBuilder : Builder<ProductCategoryModel>
{
    public ProductCategoryBuilder()
    {
        Model = new ProductCategoryModel();
    }
    public ProductCategoryBuilder SetBasicCategory(int id, string name)
    {
        Model.Id = id;
        Model.Name = name;
        return this;
    }
    public ProductCategoryBuilder SetBasicCategory(string name)
    {
        Model.Name = name;
        return this;
    }
    public ProductCategoryBuilder SetId(int id)
    {
        Model.Id = id;
        return this;
    }
    public ProductCategoryBuilder SetParentCategoryId(int id)
    {
        Model.ParentCategoryId = id;
        return this;
    }
    public ProductCategoryBuilder AddFieldKeyId(int id)
    {
        Model.FieldKeysId.Add(id);
        return this;
    }

    public ProductCategoryBuilder AddFieldKeysId(ICollection<int> ids)
    {
        Model.FieldKeysId.AddRange(ids);
        return this;
    }
    public ProductCategoryBuilder AddProductId(int id)
    {
        Model.ProductsId.Add(id);
        return this;
    }
    public ProductCategoryBuilder AddProductsId(ICollection<int> ids)
    {
        Model.ProductsId.AddRange(ids);
        return this;
    }
    public override ProductCategoryModel Build()
    {
        return Model;
    }
}