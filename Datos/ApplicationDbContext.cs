#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: ApplicationDbContext.cs
// 
// Creado:              29 / 08 / 2023 - 09:03 p. m.
// Última modificación: 29 / 08 / 2023 - 09:09 p. m.
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

#region Referencias Usadas

using ApiEjemploJWT.Datos;
using Microsoft.EntityFrameworkCore;

#endregion

namespace ApiEjemplo.Datos;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }
}