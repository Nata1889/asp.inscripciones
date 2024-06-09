using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    public class anioCarrerasController : Controller
    {
        private readonly InscripcionesContext _context;

        public anioCarrerasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: anioCarreras
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.anioCarreras.Include(a => a.Carrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: anioCarreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.anioCarreras
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            return View(anioCarrera);
        }

        // GET: anioCarreras/Create
        public IActionResult Create()
        {
            ViewData["Carreras"] = new SelectList(_context.carreras, "Id", "Nombre");
            return View();
        }

        // POST: anioCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,carreraId")] anioCarrera anioCarrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anioCarrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carreras"] = new SelectList(_context.carreras, "Id", "Nombre", anioCarrera.carreraId);
            return View(anioCarrera);
        }

        // GET: anioCarreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.anioCarreras.FindAsync(id);
            if (anioCarrera == null)
            {
                return NotFound();
            }
            ViewData["Carreras"] = new SelectList(_context.carreras, "Id", "Nombre", anioCarrera.carreraId);
            return View(anioCarrera);
        }

        // POST: anioCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,carreraId")] anioCarrera anioCarrera)
        {
            if (id != anioCarrera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anioCarrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!anioCarreraExists(anioCarrera.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Carreras"] = new SelectList(_context.carreras, "Id", "Nombre", anioCarrera.carreraId);
            return View(anioCarrera);
        }

        // GET: anioCarreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarrera = await _context.anioCarreras
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarrera == null)
            {
                return NotFound();
            }

            return View(anioCarrera);
        }

        // POST: anioCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anioCarrera = await _context.anioCarreras.FindAsync(id);
            if (anioCarrera != null)
            {
                _context.anioCarreras.Remove(anioCarrera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool anioCarreraExists(int id)
        {
            return _context.anioCarreras.Any(e => e.Id == id);
        }
    }
}
