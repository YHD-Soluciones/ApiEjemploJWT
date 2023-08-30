#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: Usuario.cs
// 
// Creado:              29 / 08 / 2023 - 09:03 p. m.
// Última modificación: 29 / 08 / 2023 - 09:07 p. m.
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

    [Required] public Guid RolId { get; set; } = Guid.Empty;

    [ForeignKey("RolId")] public Rol? Rol { get; set; }
}