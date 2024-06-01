namespace Pajophone.Models.Builders;

public class ProductFieldBuilder : Builder<ProductFieldModel>
{
    public ProductFieldBuilder()
    {
        Model = new ProductFieldModel();
    }

    public ProductFieldBuilder SetBasicFiled(string key, string value)
    {
        Model.Key = key;
        Model.Value = value;
        return this;
    }

    public override ProductFieldModel Build()
    {
        return Model;
    }
}