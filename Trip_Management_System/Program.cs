using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.interfaces;
using Service.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MyMapper));

// add all services from ExtentionService class
builder.Services.AddService();

//swagger

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContext, DataBase>();

// Register the DbContext for database access
//builder.Services.AddDbContext<DataBase>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapRazorPages();

// Maps controllers to the routing system so HTTP requests can reach them

app.MapControllers();


app.Run();
