using System.ComponentModel.DataAnnotations;


namespace Pajophone.Models;

public interface IBaseModel
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastEditedAt { get; set; }
}