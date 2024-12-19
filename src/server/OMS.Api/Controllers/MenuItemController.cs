using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMS.Business.Dtos;
using OMS.Business.Services;
using OMS.DataAccess.Entities;

namespace OMS.Api.Controllers;

[ApiController]
[Route("api/menu-item")]
public class MenuItemController : ControllerBase
{
    private readonly ILogger<MenuItemController> _logger;
    private readonly IMenuItemService _service;
    public MenuItemController(ILogger<MenuItemController> logger, IMenuItemService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("")]
    public async Task<IEnumerable<MenuItem>> GetAll()
    {
        return await _service.GetAllAsyc();
    }

    [HttpPost("create")]
    public async Task<MenuItem> Create([FromBody] MenuItemDto item)
    {
        return await _service.Create(new MenuItem { Name = item.Name, Price = item.Price });
    }

    [HttpPut("update")]
    public async Task<bool> Update(MenuItem item)
    {
        return await _service.Update(item);
    }

    [HttpPost("delete")]
    public async Task<bool> Delete([FromBody] MenuItemDeleteDto item)
    {        
        return await _service.Delete(item.Id);
    }

}
