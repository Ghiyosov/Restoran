using Infrastructure.DataContext;
using Infrastructure.Services.CustomerService;
using Infrastructure.Services.MenuItemService;
using Infrastructure.Services.OrderService;
using Infrastructure.Services.TableService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<IContext, Context>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IManuItemService, MenuItemService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Restoran API"));
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();


