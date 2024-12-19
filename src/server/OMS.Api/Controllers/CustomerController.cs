using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OMS.Business.Services;
using OMS.DataAccess.Entities;

namespace OMS.Api.Controllers;

[ApiController]
[Route("api/customer")]
public class CustomerController
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _service;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("")]
    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _service.GetAllAsyc();
    }



}
