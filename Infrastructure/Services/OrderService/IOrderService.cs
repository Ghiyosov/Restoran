using Domein.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Services.OrderService;

public interface IOrderService
{
    public Task<Response<bool>> Create(Order order, string item);
    public Task<Response<bool>> UpdateStatusOrder(int orderId, string status);
    public Task<Response<List<Order>>> GetAll();
    
    public Task<Response<List<Order>>> GetOrdersByCustomer(int customerId);
}