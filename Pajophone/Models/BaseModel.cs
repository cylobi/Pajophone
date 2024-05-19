using System.ComponentModel.DataAnnotations;


namespace Pajophone.Models;

public class BaseModel
{
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastEditedAt { get; set; }
}