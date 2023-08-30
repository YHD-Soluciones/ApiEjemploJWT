#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: AuthController.cs
// 
// Creado:              29 / 08 / 2023 - 09:03 p. m.
// Última modificación: 29 / 08 / 2023 - 09:55 p. m.
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

#region Referencias Usadas

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ApiEjemplo.Datos;
using ApiEjemploJWT.Datos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.Models.Requests;
using Shared.Models.Responses;

#endregion

namespace ApiEjemploJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;


    public AuthController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    [HttpPost("registro")]
    public async Task<ActionResult<RegisterResponse>> Registro(RegisterRequest registerRequest)
    {
        if (string.IsNullOrEmpty(registerRequest.NombreUsuario) || string.IsNullOrEmpty(registerRequest.Password))
            return BadRequest("Nombre de usuario o contraseña vacía");

        var usuario = new Usuario
        {
            NombreUsuario = registerRequest.NombreUsuario,
            Password = GetSha1(registerRequest.Password)
        };
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();

        var response = new RegisterResponse
        {
            Id = usuario.Id,
            NombreUsuario = usuario.NombreUsuario
        };
        return Ok(response);
    }


    [HttpPost("autenticar")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Autenticar(LoginRequest loginRequest)
    {
        if (string.IsNullOrEmpty(loginRequest.NombreUsuario) || string.IsNullOrEmpty(loginRequest.Password))
            return Unauthorized("Nombre de usuario o contraseña vacía");

        var data = await _context.Usuarios.Where(w =>
                w.NombreUsuario == loginRequest.NombreUsuario && w.Password == GetSha1(loginRequest.Password))
            .Include(i => i.Rol)
            .FirstOrDefaultAsync();
        if (data == null) return Unauthorized("Nombre de Usuario o contraseña incorrecta");

        var response = new LoginResponse
        {
            JwtToken = CrearToken(data),
            UsuarioId = data.Id
        };

        return Ok(response);
    }

    private string GetSha1(string value)
    {
        var data = Encoding.ASCII.GetBytes(value);
        var hashData = SHA1.HashData(data);
        var hash = string.Empty;
        foreach (var b in hashData) hash += b.ToString("X2");
        return hash;
    }

    private string CrearToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, usuario.NombreUsuario),
            new(ClaimTypes.Role, usuario.Rol.Nombre)
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}