using System.Text;
using CSharpCoban.DataAccess.Netcore.DataObject;
using CSharpCoban.DataAccess.Netcore.EfCore;
using CSharpCoban.DataAccess.Netcore.GenericRepositoy;
using CSharpCoban.DataAccess.Netcore.IGenericRepositoy;
using CSharpCoban.DataAccess.Netcore.IRepository;
using CSharpCoban.DataAccess.Netcore.Repository;
using CSharpCoban.DataAccess.Netcore.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NetCore.API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<CSharpCoBanDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Ten_ConnStr")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
        ValidAudience = builder.Configuration["Jwt:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
    };
});
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration = configuration["RedisCacheUrl"]; });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountGenericRepository, AccountGenericRepository>();
builder.Services.AddScoped<IFunctionRepository, FunctionRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMyMiddleware(); // tự mình định nghĩa middleware


app.Run();
