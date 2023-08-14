#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: pl
//  Proyecto: Shared
//  Fichero: LoginRequest.cs
// 
// Creado:              28 / 07 / 2023 - 7:53
// Última modificación: 28 / 07 / 2023 - 7:54
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

namespace Shared.Models.Requests;

public class LoginRequest
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}