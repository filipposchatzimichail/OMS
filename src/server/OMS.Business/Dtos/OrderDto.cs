using OMS.DataAccess.Entities;

namespace OMS.Business.Dtos;

public class OrderCreateDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? AddressLine { get; set; }
    public string? Postcode { get; set; }
    public required string PhoneNumber { get; set; }
    public string? SpecialInstructions { get; set; }
    public float TotalPrice { get; set; }    
    public required List<OrderItemDto> Basket { get; set; }
}
public class OrderDto : Order
{
    public required List<OrderItemDto> Basket { get; set; }
}
