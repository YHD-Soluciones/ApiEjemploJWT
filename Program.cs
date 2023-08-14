#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: Program.cs
// 
// Creado:              13 / 08 / 2023 - 23:31
// Última modificación: 14 / 08 / 2023 - 0:42
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

#region Referencias Usadas

using System.Text;
using ApiEjemplo.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//JWT
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:token").Value!))
    };
});
//</JWT>

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