using ECommerceCompanyApplication.Helpers;
using ECommerceCompanyApplication.Models;
using ECommerceCompanyApplication.Repositories;
using ECommerceCompanyApplication.Repositories.Contracts;
using ECommerceCompanyApplication.Services;
using ECommerceCompanyApplication.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "myPolicy",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    });

builder.Services.AddDbContext<ECommerceDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MySqlServer")));


builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerServices>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();


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

app.UseMiddleware<SecurityHeaderMiddleware>();

app.UseHttpsRedirection();

app.UseCors("myPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
