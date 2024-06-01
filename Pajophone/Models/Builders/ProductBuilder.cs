namespace Pajophone.Models.Builders;

public class ProductBuilder : Builder<ProductModel>
{
        public ProductBuilder()
        {
                Model = new ProductModel();
        }
        protected ProductBuilder SetBasicProduct(string name, string description, string color)
        {
                Model.Name = name;
                Model.Description = description;
                Model.Color = color;
                return this;
        }
        public ProductBuilder SetId(int id)
        {
                Model.Id = id;
                return this;
        }
        public ProductBuilder AddImage(IFormFile file)
        {
                Model.Image = ConvertIFormFileToByteArray(file);
                return this;
        }
        
        public ProductBuilder AddCategory(int categoryId)
        {
                Model.CategoryId = categoryId;
                return this;
        }
        public ProductBuilder AddField(ProductFieldModel field)
        {
                Model.ExtraFields.Add(field);
                return this;
        }
        public ProductBuilder SetFields(List<ProductFieldModel> fields)
        {
                Model.ExtraFields = fields;
                return this;
        }
        public ProductBuilder AddFields(List<ProductFieldModel> fields)
        {
                Model.ExtraFields.AddRange(fields);
                return this;
        }
        public override ProductModel Build()
        {
                Model.LastEditedAt = DateTime.Now;
                return Model;
        }
        private byte[] ConvertIFormFileToByteArray(IFormFile formFile)
        {
                using var memoryStream = new MemoryStream();
                formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
        }
}