using Pajophone.Models;
namespace Pajophone.ViewModels;

public class ProductFieldKeyViewModel : IViewModel
{
    public int? Id { get; set; }
    public string Key { get; set; }
    public FieldType FieldType { get; set; }
}