using System.ComponentModel.DataAnnotations;

namespace OMS.DataAccess.Entities;

public class Customer
{
    [Key]
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? AddressLine { get; set; }
    public string? Postcode { get; set; }
    public required string PhoneNumber { get; set; }
    public string? SpecialInstructions { get; set; }
}
