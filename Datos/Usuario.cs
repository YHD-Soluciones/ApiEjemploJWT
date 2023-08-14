#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: Usuario.cs
// 
// Creado:              14 / 08 / 2023 - 0:54
// Última modificación: 14 / 08 / 2023 - 0:54
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

#region Referencias Usadas

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace ApiEjemploJWT.Datos;

[Table("Usuarios")]
public class Usuario
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public string NombreUsuario { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}