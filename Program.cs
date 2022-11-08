using CSApiRestPractice02.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CustomerService>(mysqlBuilder => {

    mysqlBuilder.UseMySQL(builder.Configuration.GetConnectionString("MySQLConnection"));

});

builder.Services.AddDbContext<AddressService>(mysqlBuilder => {

    mysqlBuilder.UseMySQL(builder.Configuration.GetConnectionString("MySQLConnection"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
