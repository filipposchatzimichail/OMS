using System.ComponentModel.DataAnnotations;

namespace OMS.DataAccess.Entities;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    public required OrderStatus Status { get; set; }
    public float TotalPrice { get; set; }
    public Guid CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public bool IsDelivery { get; set; }
}
