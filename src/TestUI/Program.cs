using Kreta.FileService.ParameterHandler.Caching;
using Kreta.FileService.ParameterHandler.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddQueryParameterHandlers();
builder.Services.AddQueryParameterHandlerCaching();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseQueryParameterHandlerCaching();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
