using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController(ICustomerService _service):ControllerBase
{
    [HttpGet("GetCustomers")]
    public async Task<Response<List<Customer>>> GetCustomers()
    {
        return await _service.GetAll();
    }

    [HttpGet("GetCustomer/{name}")]
    public async Task<Response<Customer>> GetCustomerByName(string name)
    {
        return await _service.GetByName(name);
    }

    [HttpGet("GetCustomer/{phoneNumber}")]
    public async Task<Response<Customer>> GetCustomerByPhone(string phoneNumber)
    {
        return await _service.GetByPoneNumber(phoneNumber);
    }

    [HttpPost("AddCustomer")]
    public async Task<Response<bool>> AddCustomer([FromBody] Customer customer)
    {
        return await _service.Create(customer);
    }

    [HttpDelete("DeleteCustomer/{id}")]
    public async Task<Response<bool>> DeleteCustomer(int id)
    {
        return await _service.Delete(id);
    }
}