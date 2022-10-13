using Microsoft.EntityFrameworkCore;
using Web3MusicStore.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreDbContext>(opts => // DB Service
{
  opts.UseSqlServer(builder.Configuration["ConnectionStrings:StoreConnection"]); // Retrieve connection string from appsettings.json
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
