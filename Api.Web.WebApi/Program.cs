using Api.Web.WebApi.Infrastructure.Interfaces;
using Api.Web.WebApi.Infrastructure.Services;
using Api.Web.WebApi.Infrastructure.ServiceConection;
using Api.Web.WebApi.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
//builder.Services.AddDbContext<DbContext>(options =>
//        options.UseSqlServer("name=CadenaSQL"));

builder.Services.AddScoped<IServicesGeneric, ServicesGeneric>();
builder.Services.AddScoped<IRepositoryGeneric, RepositoryGeneric>();
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
