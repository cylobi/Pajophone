using Pajophone.Models;

namespace Pajophone.ViewModels;

public class ProductFieldViewModel : IViewModel
{
    public int? KeyId { get; set; }
    public int? ValueId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public FieldType fieldType { get; set; }
}