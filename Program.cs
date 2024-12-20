using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using AgroProject.Data;
using AgroProject.Services;
using AgroProject.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Добавление конфигурации базы данных
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление сервисов
builder.Services.AddScoped<ICultureService, CultureService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IReagentService, ReagentService>();
builder.Services.AddScoped<IReagentUsageService, ReagentUsageService>();
builder.Services.AddScoped<IProtokolService, ProtokolService>();
builder.Services.AddScoped<ISampleService, SampleService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Добавление CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

// Настройка аутентификации JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();


var app = builder.Build();

// Использование CORS
app.UseCors("AllowOrigin");

// Использование аутентификации и авторизации
app.UseAuthentication();
app.UseAuthorization();

// Настройка маршрутизации
app.MapControllers();

// Запуск приложения
app.Run();