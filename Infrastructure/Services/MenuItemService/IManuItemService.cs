using Domein.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Services.MenuItemService;

public interface IManuItemService
{
    public Task<Response<List<MenuItem>>> GetAll();
    public Task<Response<bool>> Creat(MenuItem item);
    
}