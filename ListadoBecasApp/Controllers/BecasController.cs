using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListadoBecasApp.Models;

namespace ListadoBecasApp.Controllers
{
    public class BecasController : Controller
    {
        private readonly BecasAppContext _context;

        public BecasController(BecasAppContext context)
        {
            _context = context;
        }

        // GET: Becas
        public async Task<IActionResult> Index(int? carreraId)
        {
            var carreras = await _context.Carreras.ToListAsync();
            ViewBag.Carreras = new SelectList(carreras, "IdCarrera", "NombreCarrera");

            var becas = await _context.Becas
                                      .Include(b => b.IdCarreraNavigation)
                                      .ToListAsync();

            if (carreraId.HasValue)
            {
                becas = becas.Where(b => b.IdCarrera == carreraId.Value).ToList();

                var becaSeleccionada = becas.FirstOrDefault();
                if (becaSeleccionada != null)
                {
                    ViewBag.PorcentajeBeca = becaSeleccionada.PorcentajeBeca;
                }
            }

            return View(becas);
        }

        // GET: Becas/Administrations 
        [HttpGet]
        [Route("becas/administrations")]
        public async Task<IActionResult> Administrations(string sortOrder)
        {
            // Inicializar variables de ordenación en la vista
            ViewBag.NombreSort = sortOrder == "nombre_asc" ? "nombre_desc" : "nombre_asc";
            ViewBag.PorcentajeSort = sortOrder == "porcentaje_asc" ? "porcentaje_desc" : "porcentaje_asc";
            ViewBag.CarreraSort = sortOrder == "carrera_asc" ? "carrera_desc" : "carrera_asc";

            // Obtener la lista de becas con la relación de IdCarreraNavigation
            var becas = await _context.Becas
                                      .Include(b => b.IdCarreraNavigation)
                                      .ToListAsync();

            // Aplicar la ordenación en función de sortOrder
            switch (sortOrder)
            {
                case "nombre_desc":
                    becas = becas.OrderByDescending(b => b.NombreBeca).ToList();
                    break;
                case "nombre_asc":
                    becas = becas.OrderBy(b => b.NombreBeca).ToList();
                    break;
                case "porcentaje_desc":
                    becas = becas.OrderByDescending(b => b.PorcentajeBeca).ToList();
                    break;
                case "porcentaje_asc":
                    becas = becas.OrderBy(b => b.PorcentajeBeca).ToList();
                    break;
                case "carrera_desc":
                    becas = becas.OrderByDescending(b => b.IdCarreraNavigation?.NombreCarrera).ToList();
                    break;
                case "carrera_asc":
                    becas = becas.OrderBy(b => b.IdCarreraNavigation?.NombreCarrera).ToList();
                    break;
                default:
                    // Sin ordenamiento, mantener el orden original
                    break;
            }

            return View(becas);
        }


        // GET: Becas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beca = await _context.Becas
                .Include(b => b.IdCarreraNavigation)
                .FirstOrDefaultAsync(m => m.IdBeca == id);
            if (beca == null)
            {
                return NotFound();
            }

            return View(beca);
        }

        // GET: Becas/Create
        public IActionResult Create()
        {
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera");
            return View();
        }

        // POST: Becas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBeca,NombreBeca,Descripcion,PorcentajeBeca,FechaInicio,FechaFin,IdCarrera")] Beca beca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Administrations));
            }

            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera", beca.IdCarrera);
            return View(beca);
        }


        // GET: Becas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beca = await _context.Becas.FindAsync(id);
            if (beca == null)
            {
                return NotFound();
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera", beca.IdCarrera);
            return View(beca);
        }

        // POST: Becas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBeca,NombreBeca,Descripcion,PorcentajeBeca,FechaInicio,FechaFin,IdCarrera")] Beca beca)
        {
            if (id != beca.IdBeca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BecaExists(beca.IdBeca))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Administrations));
            }
            ViewData["IdCarrera"] = new SelectList(_context.Carreras, "IdCarrera", "NombreCarrera", beca.IdCarrera);
            return View(beca);
        }

        // GET: Becas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beca = await _context.Becas
                .Include(b => b.IdCarreraNavigation)
                .FirstOrDefaultAsync(m => m.IdBeca == id);
            if (beca == null)
            {
                return NotFound();
            }

            return View(beca);
        }

        // POST: Becas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beca = await _context.Becas.FindAsync(id);
            if (beca != null)
            {
                _context.Becas.Remove(beca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Administrations));
        }

        private bool BecaExists(int id)
        {
            return _context.Becas.Any(e => e.IdBeca == id);
        }
    }
}
