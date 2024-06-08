namespace Pajophone.Models.Builders;

public class ProductFieldValueBuilder : Builder<ProductFieldValueModel>
{
    public ProductFieldValueBuilder()
    {
        Model = new ProductFieldValueModel();
    }
    public ProductFieldValueBuilder SetBasicField(int keyId, string value)
    {
        Model.FieldKeyId = keyId;
        Model.Value = value;
        return this;
    }
    
    public ProductFieldValueBuilder SetBasicField(int id, int keyId, string value)
    {
        Model.Id = id;
        Model.FieldKeyId = keyId;
        Model.Value = value;
        return this;
    }
    public ProductFieldValueBuilder SetId(int id)
    {
        Model.Id = id;
        return this;
    }
    public override ProductFieldValueModel Build()
    {
        return Model;
    }
}