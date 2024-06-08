using Pajophone.Models;
namespace Pajophone.ViewModels;

public class ProductFieldValueViewModel : IViewModel
{
    public int Id { get; set; }
    public string Value { get; set; }
    public FieldType fieldType { get; set; }
}