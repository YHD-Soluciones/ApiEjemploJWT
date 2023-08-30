#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: Rol.cs
// 
// Creado:              29 / 08 / 2023 - 09:05 p. m.
// Última modificación: 29 / 08 / 2023 - 09:19 p. m.
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

#region Referencias Usadas

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace ApiEjemploJWT.Datos;

[Table("Roles")]
public class Rol
{
    [Key] [Required] public Guid Id { get; set; } = Guid.NewGuid();

    [Required] public string Nombre { get; set; } = string.Empty;
}