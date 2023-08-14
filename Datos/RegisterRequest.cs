#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: pl
//  Proyecto: Shared
//  Fichero: RegisterRequest.cs
// 
// Creado:              28 / 07 / 2023 - 7:53
// Última modificación: 28 / 07 / 2023 - 9:06
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

namespace Shared.Models.Requests;

public class RegisterRequest
{
    public string NombreUsuario { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime Creado { get; set; } = DateTime.Now;
}