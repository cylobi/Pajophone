namespace Pajophone.Models.Builder;

public interface IProductBuilder
{
    public ProductBuilder BuildBasicProduct(string name, string description, string color);
    public ProductBuilder SetId(int id);
    public ProductBuilder AddCategory(string name);
    // public ProductBuilder AddSubCategory(string name, string parentCategoryName); //TODO:
    public ProductBuilder AddField(string key, string value);
    //TODO: Design & Implement AddExtraFields
    // public ProductBuilder AddExtraFields(Dictionary<string, object> extraFields); ??
    public ProductModel Build();
}