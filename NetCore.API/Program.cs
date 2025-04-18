using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.EfCore;
using CSharpCoban.DataAccess.Netcore.GenericRepositoy;
using CSharpCoban.DataAccess.Netcore.IGenericRepositoy;
using CSharpCoban.DataAccess.Netcore.IRepository;
using CSharpCoban.DataAccess.Netcore.Repository;
using CSharpCoban.DataAccess.Netcore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using NetCore.API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<CSharpCoBanDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Ten_ConnStr")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountGenericRepository, AccountGenericRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});
//app.UseMiddleware<MyCustomMiddleware>();


app.UseAuthorization();

app.MapControllers();

app.UseMyMiddleware(); // tự mình định nghĩa middleware


app.Run();
