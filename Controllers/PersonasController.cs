#region Cabecera

// ---------------------------------------------------
//  Autor: JotaAP
//  Solución: ApiEjemploJWT
//  Proyecto: ApiEjemploJWT
//  Fichero: PersonasController.cs
// 
// Creado:              29 / 08 / 2023 - 09:03 p. m.
// Última modificación: 29 / 08 / 2023 - 09:24 p. m.
// 
//  Copyright: YHD Soluciones. © 2023
// ---------------------------------------------------

#endregion

#region Referencias Usadas

using ApiEjemplo.Datos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#endregion

namespace ApiEjemploJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Administrador")]
public class PersonasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PersonasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Personas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
    {
        if (_context.Personas == null) return NotFound();
        return await _context.Personas.ToListAsync();
    }

    // GET: api/Personas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Persona>> GetPersona(Guid id)
    {
        if (_context.Personas == null) return NotFound();
        var persona = await _context.Personas.FindAsync(id);

        if (persona == null) return NotFound();

        return persona;
    }

    // PUT: api/Personas/5

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPersona(Guid id, Persona persona)
    {
        if (id != persona.Id) return BadRequest();

        _context.Entry(persona).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonaExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Personas
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Persona>> PostPersona(Persona persona)
    {
        if (_context.Personas == null) return Problem("Entity set 'ApplicationDbContext.Personas'  is null.");
        _context.Personas.Add(persona);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPersona", new { id = persona.Id }, persona);
    }

    // DELETE: api/Personas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersona(Guid id)
    {
        if (_context.Personas == null) return NotFound();
        var persona = await _context.Personas.FindAsync(id);
        if (persona == null) return NotFound();

        _context.Personas.Remove(persona);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    private bool PersonaExists(Guid id)
    {
        return (_context.Personas?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}