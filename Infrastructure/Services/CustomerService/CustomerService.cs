using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services.CustomerService;

public class CustomerService(IContext _context) : ICustomerService
{
    public async Task<Response<List<Customer>>> GetAll()
    {
        var sql = @"select * from customers";
        var res = await _context.Connection().QueryAsync<Customer>(sql);
        return new Response<List<Customer>>(res.ToList());
    }

    public async Task<Response<Customer>> GetByName(string name)
    {
        var sql = @"select * from customers where name = @name";
        var res = await _context.Connection().QuerySingleOrDefaultAsync<Customer>(sql, new { name });
        return new Response<Customer>(res);
    }

    public async Task<Response<Customer>> GetByPoneNumber(string poneNumber)
    {
        var sql = @"select * from customers where phonenumber = @poneNumber";
        var res = await _context.Connection().QuerySingleOrDefaultAsync<Customer>(sql, new { poneNumber });
        return new Response<Customer>(res);
    }

    public async Task<Response<bool>> Create(Customer customer)
    {
        var sql = @"insert into customers(Name, PhoneNumber) values (@name, @phoneNumber);";
        var res = await _context.Connection().ExecuteAsync(sql, customer);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Created");
    }

    public async Task<Response<bool>> Delete(int customerId)
    {
        var sql = @"delete from customers where customerId = @customerId";
        var res = await _context.Connection().ExecuteAsync(sql, new { customerId });
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Customer Deleted");

    }
}