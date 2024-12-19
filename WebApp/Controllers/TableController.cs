using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services.TableService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class TableController(ITableService _service):ControllerBase
{
    [HttpGet("GetTables")]
    public async Task<Response<List<Table>>> GetTables()
    {
        return await _service.GetAllTablesAsync();
    }

    [HttpPut("UpdateTableToBookings")]
    public async Task<Response<bool>> TableToBookings(int tableId)
    {
        return await _service.UpdateStatusTableToBookings(tableId);
    }

    [HttpPut("UpdateTableToFree")]
    public async Task<Response<bool>> TableToFree(int tableId)
    {
        return await _service.UpdateStatusTableToFree(tableId);
    }

    [HttpGet("GetFreeTables")]
    public async Task<Response<List<Table>>> GetFreeTables()
    {
        return await _service.GetFreeTables();
    }

    [HttpPut("ChangeStatusAndTableNumber")]
    public async Task<Response<bool>> ChangeStatusAndTableNumber(int id, string tableNumber, string isOccupied)
    {
        return await _service.ChangeStatusAndTableNumber(id, tableNumber, isOccupied);
    }
}