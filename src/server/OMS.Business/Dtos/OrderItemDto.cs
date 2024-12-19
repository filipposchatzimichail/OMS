using OMS.DataAccess.Entities;

namespace OMS.Business.Dtos;


public class OrderItemDto
{
    public required MenuItem Item { get; set; }
    public int Quantity { get; set; }
}