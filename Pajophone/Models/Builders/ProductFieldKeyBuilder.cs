namespace Pajophone.Models.Builders;

public class ProductFieldKeyBuilder : Builder<ProductFieldKeyModel>
{
    public ProductFieldKeyBuilder()
    {
        Model = new ProductFieldKeyModel();
    }

    public ProductFieldKeyBuilder SetBasicField(string key, FieldType fieldType)
    {
        Model.Key = key;
        Model.FieldType = fieldType;
        return this;
    }
    
    public ProductFieldKeyBuilder SetBasicField(int id, string key, FieldType fieldType)
    {
        Model.Id = id;
        Model.Key = key;
        Model.FieldType = fieldType;
        return this;
    }

    public ProductFieldKeyBuilder SetCategory(ProductCategoryModel category)
    {
        Model.Category = category;
        return this;
    }

    public ProductFieldKeyBuilder SetId(int id)
    {
        Model.Id = id;
        return this;
    }

    public override ProductFieldKeyModel Build()
    {
        return Model;
    }
}