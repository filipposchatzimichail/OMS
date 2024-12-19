using System.ComponentModel.DataAnnotations;

namespace OMS.DataAccess.Entities;

public class MenuItem
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public float Price { get; set; }

}
