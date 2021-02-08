using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Touhouplanet.Data;
using Touhouplanet.Models;

namespace Touhouplanet.Controllers
{
    public class TouhousController : Controller
    {
        private readonly MvcTouhouContext _context;

        public TouhousController(MvcTouhouContext context)
        {
            _context = context;
        }

        // GET: Touhous
        public async Task<IActionResult> Index(string TouhouEspecie, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from t in _context.Touhou
                                            orderby t.Especie
                                            select t.Especie;

            var touhou = from t in _context.Touhou
                         select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                touhou = touhou.Where(s => s.Nombre.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(TouhouEspecie))
            {
                touhou = touhou.Where(x => x.Especie == TouhouEspecie);
            }

            var TouhouVM = new TouhouEspecieViewModel
            {
                Especies = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Touhous = await touhou.ToListAsync()
            };

            return View(TouhouVM);
        }

        // GET: Touhous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touhou = await _context.Touhou
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touhou == null)
            {
                return NotFound();
            }

            return View(touhou);
        }

        // GET: Touhous/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Touhous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Especie,Habilidad,Ocupacion,Ubicacion, Imagen")] Touhou touhou)
        {
            if (ModelState.IsValid)
            {
                _context.Add(touhou);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(touhou);
        }

        // GET: Touhous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touhou = await _context.Touhou.FindAsync(id);
            if (touhou == null)
            {
                return NotFound();
            }
            return View(touhou);
        }

        // POST: Touhous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Especie,Habilidad,Ocupacion,Ubicacion,Imagen")] Touhou touhou)
        {
            if (id != touhou.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(touhou);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TouhouExists(touhou.Id))
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
            return View(touhou);
        }

        // GET: Touhous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var touhou = await _context.Touhou
                .FirstOrDefaultAsync(m => m.Id == id);
            if (touhou == null)
            {
                return NotFound();
            }

            return View(touhou);
        }

        // POST: Touhous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var touhou = await _context.Touhou.FindAsync(id);
            _context.Touhou.Remove(touhou);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TouhouExists(int id)
        {
            return _context.Touhou.Any(e => e.Id == id);
        }
    }
}
