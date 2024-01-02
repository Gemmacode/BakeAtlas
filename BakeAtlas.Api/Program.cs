using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Application.ServicesImplementation;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;
using BakeAtlas.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IBakeryProductService, BakeryProductService>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

builder.Services.AddIdentity<Customer, IdentityRole>()
            .AddEntityFrameworkStores<BakeAtlasDbContext>()
            .AddDefaultTokenProviders();

builder.Services.AddDbContext<BakeAtlasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
