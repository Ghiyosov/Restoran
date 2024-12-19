using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class OrederController(IOrderService _service):ControllerBase
{
    [HttpPost("CreateOreder")]
    public async Task<Response<bool>> Create(Order order, string item)
    {
        return await _service.Create(order, item);
    }

    [HttpGet("GetOreders")]
    public async Task<Response<List<Order>>> GetOreders()
    {
        return await _service.GetAll();
    }

    [HttpGet("ChengeStatus")]
    public async Task<Response<bool>> ChengeStatus(int id,string status)
    {
        return await _service.UpdateStatusOrder(id,status);
    }

    [HttpGet("CustomerOrders")]
    public async Task<Response<List<Order>>> GetCustomerOrders(int id)
    {
        return await _service.GetOrdersByCustomer(id);
    }
}