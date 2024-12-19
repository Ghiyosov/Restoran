using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services.MenuItemService;

public class MenuItemService(IContext _context) : IManuItemService
{
    public async Task<Response<List<MenuItem>>> GetAll()
    {
        var sql = @"select * from MenuItems";
        var res = await _context.Connection().QueryAsync<MenuItem>(sql);
        return new Response<List<MenuItem>>(res.ToList());
    }

    public async Task<Response<bool>> Creat(MenuItem item)
    {
        var sql = @"insert into MenuItems(Name, Price, Category) values (@Name, @Price, @Category)";
        var res = await _context.Connection().ExecuteAsync(sql, item);
        return res == 0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.Created, "Created"); 
    }
}