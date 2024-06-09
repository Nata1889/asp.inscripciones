using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApianioCarreras1Controller : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApianioCarreras1Controller(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApianioCarreras1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<anioCarrera>>> GetanioCarreras()
        {
            return await _context.anioCarreras.ToListAsync();
        }

        // GET: api/ApianioCarreras1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<anioCarrera>> GetanioCarrera(int id)
        {
            var anioCarrera = await _context.anioCarreras.FindAsync(id);

            if (anioCarrera == null)
            {
                return NotFound();
            }

            return anioCarrera;
        }

        // PUT: api/ApianioCarreras1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutanioCarrera(int id, anioCarrera anioCarrera)
        {
            if (id != anioCarrera.Id)
            {
                return BadRequest();
            }

            _context.Entry(anioCarrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!anioCarreraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApianioCarreras1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<anioCarrera>> PostanioCarrera(anioCarrera anioCarrera)
        {
            _context.anioCarreras.Add(anioCarrera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetanioCarrera", new { id = anioCarrera.Id }, anioCarrera);
        }

        // DELETE: api/ApianioCarreras1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteanioCarrera(int id)
        {
            var anioCarrera = await _context.anioCarreras.FindAsync(id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            _context.anioCarreras.Remove(anioCarrera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool anioCarreraExists(int id)
        {
            return _context.anioCarreras.Any(e => e.Id == id);
        }
    }
}
