#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: LoginResponse.cs
// 
// Creado:              14 / 08 / 2023 - 1:15
// Última modificación: 14 / 08 / 2023 - 1:40
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

namespace Shared.Models.Responses;

public class LoginResponse
{
    public Guid UsuarioId { get; set; } = Guid.Empty;

    public string JwtToken { get; set; } = string.Empty;
}