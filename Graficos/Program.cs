using Graficos.Models;
using Graficos.Models.Response;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GraficasContext>();

builder.Services.AddCors(p => p.AddPolicy("corseapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("corseapp");

app.MapGet("/", () => "Hello World!");
app.MapGet("/stock", async (GraficasContext context) => 
{
    return await context.Stocks.Select(b => new StockResponse
    {
        Name = b.Beer.Name,
        Quantity = b.Quantity
    }).ToListAsync();
});

app.Run();
