namespace OMS.Business.Dtos;

public class MenuItemDto
{
    public required string Name { get; set; }
    public required float Price { get; set; }
}
public class MenuItemDeleteDto
{
    public required Guid Id { get; set; }
}
