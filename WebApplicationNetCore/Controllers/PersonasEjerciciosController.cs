using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Controllers
{
    public class PersonasEjerciciosController : Controller
    {
        private PersonaSoapContext _context;

        public PersonasEjerciciosController(PersonaSoapContext context)
        {
            _context = context;
        }

        // GET: PersonasEjercicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonasEjercicio.ToListAsync());
        }

        // GET: PersonasEjercicios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasEjercicio = await _context.PersonasEjercicio
                .FirstOrDefaultAsync(m => m.Nif == id);
            if (personasEjercicio == null)
            {
                return NotFound();
            }

            return View(personasEjercicio);
        }

        // GET: PersonasEjercicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonasEjercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nif,Nombre,Apellidos,Direccion,Ciudad,EstadoCivil,Sexo,CodigoPostal,Provincia")] PersonasEjercicio personasEjercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personasEjercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personasEjercicio);
        }

        // GET: PersonasEjercicios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasEjercicio = await _context.PersonasEjercicio.FindAsync(id);
            if (personasEjercicio == null)
            {
                return NotFound();
            }
            return View(personasEjercicio);
        }

        // POST: PersonasEjercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nif,Nombre,Apellidos,Direccion,Ciudad,EstadoCivil,Sexo,CodigoPostal,Provincia")] PersonasEjercicio personasEjercicio)
        {
            if (id != personasEjercicio.Nif)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personasEjercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasEjercicioExists(personasEjercicio.Nif))
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
            return View(personasEjercicio);
        }

        // GET: PersonasEjercicios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasEjercicio = await _context.PersonasEjercicio
                .FirstOrDefaultAsync(m => m.Nif == id);
            if (personasEjercicio == null)
            {
                return NotFound();
            }

            return View(personasEjercicio);
        }

        // POST: PersonasEjercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personasEjercicio = await _context.PersonasEjercicio.FindAsync(id);
            _context.PersonasEjercicio.Remove(personasEjercicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasEjercicioExists(string id)
        {
            return _context.PersonasEjercicio.Any(e => e.Nif == id);
        }
    }
}
