using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMS.Business.Services;
using OMS.DataAccess.Entities;

namespace OMS.Api.Controllers;

[ApiController]
[Route("api/order-item")]
public class OrderItemController : ControllerBase
{
    private readonly ILogger<OrderItemController> _logger;
    private readonly IOrderItemService _service;
    public OrderItemController(ILogger<OrderItemController> logger, IOrderItemService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("")]
    public async Task<IEnumerable<OrderItem>> GetAll()
    {
        return await _service.GetAllAsyc();
    }
}
