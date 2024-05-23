namespace Pajophone.Models.Builder;

public class ProductBuilder
{
        protected ProductModel Product { get; set; }

        public ProductBuilder()
        {
                Product = new ProductModel();
        }

        public ProductBuilder BuildBasicProduct(string name, string description, string color)
        {
                Product.Name = name;
                Product.Description = description;
                Product.Color = color;
                return this;
        }
        
        public ProductBuilder SetId(int id)
        {
                Product.Id = id;
                return this;
        }

        public ProductBuilder AddImage(IFormFile file)
        {
                Product.Image = ConvertIFormFileToByteArray(file);
                return this;
        }
        
        public ProductBuilder AddCategory(string name)
        {
                ProductCategoryModel category = new ProductCategoryModel();
                category.Name = name;
                Product.Category = category;
                return this;
        }
        
        public ProductBuilder AddField(string key, string value)
        {
                ProductFieldModel field = new ProductFieldModel();
                field.key = key;
                field.value = value;
                Product.ExtraFields.Add(field);
                return this;
        }

        public ProductModel Build()
        { 
                return Product;
        }
        
        protected byte[] ConvertIFormFileToByteArray(IFormFile formFile)
        {
                using var memoryStream = new MemoryStream();
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
        }
}