using System.ComponentModel.DataAnnotations;

namespace CunDropShipping_Categories.infrastructure.Entity;

public class CategoriesEntity
{
    [Key]
    public int IdCategory { get; set; }
    public string? TypeCategory { get; set; }
}