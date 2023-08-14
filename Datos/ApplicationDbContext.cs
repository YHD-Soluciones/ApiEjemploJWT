#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: ApplicationDbContext.cs
// 
// Creado:              13 / 08 / 2023 - 23:33
// Última modificación: 14 / 08 / 2023 - 0:55
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
}