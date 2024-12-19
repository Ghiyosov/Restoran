using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services.OrderService;

public class OrderService(IContext _context) : IOrderService
{
    public async Task<Response<bool>> Create(Order order, string item)
    {
        var sqlOrder = @"insert into Order(CustomerId, TableId, Status) values (@CustomerId, @TableId, @Status) returns OrderId";
        var resOrder = await _context.Connection().ExecuteScalarAsync<int>(sqlOrder, order);
        var intList = item
            .Split(',')                         // Разделяем строку по запятым
            .Where(s => int.TryParse(s, out _)) // Оставляем только те элементы, которые можно преобразовать в число
            .Select(int.Parse)                  // Преобразуем строки в числа
            .ToList();                          // Преобразуем в список
        List<int> orderCount = new();
        foreach (var x in intList)
        {
            var sqlItem = @"insert into OrderItems(OrderId,MenuItemId) values (@resOrde,@x)";
            var resItem = await _context.Connection().ExecuteScalarAsync<int>(sqlItem, order);
            orderCount.Add(resItem);
        }
        return resOrder > 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, $"OrderId : {resOrder}  Count Item : {string.Join(" , ", orderCount)}");
    }

    public async Task<Response<bool>> UpdateStatusOrder(int orderId, string status)
    {
        var sqlOrder = @"update Orders set Status = @status where OrderId = @orderId";
        var resOrder = await _context.Connection().ExecuteScalarAsync<int>(sqlOrder, new{orderId, status});
        return resOrder==0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Status updated");
    }

    public async Task<Response<List<Order>>> GetAll()
    {
        var sqlOrder = @"select * from Orders";
        var orders = await _context.Connection().QueryAsync<Order>(sqlOrder);
        return new Response<List<Order>>(orders.ToList());
    }

    public async Task<Response<List<Order>>> GetOrdersByCustomer(int id)
    {
        var sqlOrder = @"select * from Orders where CustomerId = @id";
        var orders = await _context.Connection().QueryAsync<Order>(sqlOrder, new { id });
        return new Response<List<Order>>(orders.ToList());
    }
}