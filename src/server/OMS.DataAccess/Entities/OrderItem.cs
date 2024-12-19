using System.ComponentModel.DataAnnotations;

namespace OMS.DataAccess.Entities;

public class OrderItem
{
    [Key]
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public virtual Order? Order { get; set; }
    public Guid ItemId { get; set; }
    public virtual MenuItem? Item { get; set; }
    public int Quantity { get; set; }  
}
