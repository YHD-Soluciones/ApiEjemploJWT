#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: pl
//  Proyecto: Shared
//  Fichero: RegisterResponse.cs
// 
// Creado:              28 / 07 / 2023 - 7:53
// Última modificación: 28 / 07 / 2023 - 7:54
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

namespace Shared.Models.Responses;

public class RegisterResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    public string NombreUsuario { get; set; } = string.Empty;
}