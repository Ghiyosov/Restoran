using Domein.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Services.CustomerService;

public interface ICustomerService
{
    public Task<Response<List<Customer>>> GetAll();
    public Task<Response<Customer>> GetByName(string name);
    public Task<Response<Customer>> GetByPoneNumber(string poneNumber);
    public Task<Response<bool>> Create(Customer customer);
    public Task<Response<bool>> Delete(int customerId);
}