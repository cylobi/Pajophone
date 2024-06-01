using NuGet.Configuration;

namespace Pajophone.Models.Builders;

public class ProductCategoryBuilder : Builder<ProductCategoryModel>
{
    public ProductCategoryBuilder()
    {
        Model = new ProductCategoryModel();
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
    
    public override ProductCategoryModel Build()
    {
        return Model;
    }
}