using System.Net;
using Dapper;
using Domein.Entities;
using Infrastructure.DataContext;
using Infrastructure.Responses;

namespace Infrastructure.Services.TableService;

public class TableService(IContext _context) : ITableService
{
    public async Task<Response<List<Table>>> GetAllTablesAsync()
    {
        var sql = @"select * from Tables";
        var res = await _context.Connection().QueryAsync<Table>(sql);
        return new Response<List<Table>>(res.ToList());
    }

    public async Task<Response<bool>> UpdateStatusTableToBookings(int tableId)
    {
        var sql = @"update Tables set IsOccupied = 'Bookings' where TableId = @tableId";
        var res = await _context.Connection().ExecuteAsync(sql, new { tableId });
        return res==0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Status updated");
    }

    public async Task<Response<bool>> UpdateStatusTableToFree(int tableId)
    {
        var sql = @"update Tables set IsOccupied = 'Free' where TableId = @tableId";
        var res = await _context.Connection().ExecuteAsync(sql, new { tableId });
        return res==0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Status updated");
    }

    public async Task<Response<List<Table>>> GetFreeTables()
    {
        var sql = @"select * from Tables where IsOccupied = 'Free' or IsOccupied = null";
        var res = await _context.Connection().QueryAsync<Table>(sql);
        return new Response<List<Table>>(res.ToList());
    }

    public async Task<Response<bool>> ChangeStatusAndTableNumber(int id, string tableNumber, string isOccupied)
    {
        var sql = @"update Tables set IsOccupied = @isOccupied, TableNumber=@tableNumber  where TableId = @id";
        var res = await _context.Connection().ExecuteAsync(sql, new { id, isOccupied = tableNumber });
        return res==0
            ? new Response<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Response<bool>(HttpStatusCode.OK, "Status and table number updated");

    }

}