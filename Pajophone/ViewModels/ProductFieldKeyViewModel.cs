using System.ComponentModel.DataAnnotations;
using Pajophone.Models;
namespace Pajophone.ViewModels;

public class ProductFieldKeyViewModel : IViewModel
{
    public int? Id { get; set; }
    [Display(Name = "Field Key")]
    [Required(ErrorMessage = "{0} is required.")]
    public string Key { get; set; }
    [Display(Name = "Field Type")]
    [Required(ErrorMessage = "{0} is required.")]
    public FieldType FieldType { get; set; }
}