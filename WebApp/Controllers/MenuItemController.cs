using Domein.Entities;
using Infrastructure.Responses;
using Infrastructure.Services.MenuItemService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("[controller]")]
public class MenuItemController(IManuItemService _service): ControllerBase
{
    [HttpGet("GetMenuItems")]
    public async Task<Response<List<MenuItem>>> GetMenuItems()
    {
        return await _service.GetAll();
    }

    [HttpPost("AddMenuItem")]
    public async Task<Response<bool>> AddMenuItem(MenuItem _menuItem)
    {
        return await _service.Creat(_menuItem);
    }
}