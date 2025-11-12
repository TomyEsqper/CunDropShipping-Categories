using CunDropShipping_Categories.adapter.restful.v1.controller.mapper;
using CunDropShipping_Categories.application.Service;
using CunDropShipping_Categories.domain;
using CunDropShipping_Categories.infrastructure.DbContext;
using CunDropShipping_Categories.infrastructure.Entity;
using CunDropShipping_Categories.infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<Repository>();
builder.Services.AddScoped<IInfrastructureMapper, InfrastructureMapper>();
builder.Services.AddScoped<IAdapterMapper, AdapterMapper>();
builder.Services.AddScoped<ICategoriesService, CategoriesServiceImp>();

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