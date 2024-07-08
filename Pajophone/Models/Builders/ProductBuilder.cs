using System.Reflection.Metadata.Ecma335;
using NuGet.Packaging;

namespace Pajophone.Models.Builders;

public class ProductBuilder : Builder<ProductModel>
{
        public ProductBuilder()
        {
                Model = new ProductModel();
        }
        public ProductBuilder SetBasicProduct(string name, string description, string color)
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
        
        public ProductBuilder AddImage(byte[] file)
        {
                Model.Image = file;
                return this;
        }

        public ProductBuilder AddPrice(double price)
        {
                Model.Price = price;
                return this;
        }

        public ProductBuilder SetCategory(ProductCategoryModel category)
        {
                Model.Category = category;
                return this;
        }

        public ProductBuilder SetCategoryId(int categoryId)
        {
                Model.CategoryId = categoryId;
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