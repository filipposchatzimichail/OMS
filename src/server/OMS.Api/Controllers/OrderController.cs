using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMS.Business.Dtos;
using OMS.Business.Services;
using OMS.DataAccess.Entities;
using System.Collections.Generic;

namespace OMS.Api.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _service;
    public OrderController(ILogger<OrderController> logger, IOrderService service)
    {
        _logger = logger;
        _service = service;
    }


    [HttpGet("")]
    public async Task<IEnumerable<OrderDto>> GetAll()
    {
        return (IEnumerable<OrderDto>)await _service.GetAllAsDtoAsyc();
    }

    [HttpPost("create")]
    public async Task<Order> Create([FromBody] OrderCreateDto item)
    {
        return await _service.CreateFromDto(item);
    }
}
