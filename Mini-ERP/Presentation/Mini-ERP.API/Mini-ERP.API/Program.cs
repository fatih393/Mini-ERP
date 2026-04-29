using Microsoft.EntityFrameworkCore;
using Mini_ERP.Persistence;
using Mini_ERP.Persistence.Contexts;
using Mini_ERP.Application;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Mini_ErpAPIContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSwaggerGen(c =>
{
    c.UseInlineDefinitionsForEnums();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
