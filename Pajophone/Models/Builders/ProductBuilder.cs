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
        public ProductBuilder AddFieldValueId(int id)
        {
                Model.FieldvaluesId.Add(id);
                return this;
        }

        public ProductBuilder AddFieldValuesId(ICollection<int> ids)
        {
                Model.FieldvaluesId.AddRange(ids);
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