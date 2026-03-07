using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex_EF.Data;
using Pokedex_EF.Models;

namespace Pokedex_EF.Controllers
{
    public class ElementoController : Controller
    {
        private readonly PokemonDbContext _context;

        public ElementoController(PokemonDbContext context)
        {
            _context = context;
        }

        // GET: Elemento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Elementos.ToListAsync());
        }

        // GET: Elemento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elementos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }

        // GET: Elemento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Elemento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Elemento elemento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elemento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elemento);
        }

        // GET: Elemento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento == null)
            {
                return NotFound();
            }
            return View(elemento);
        }

        // POST: Elemento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Elemento elemento)
        {
            if (id != elemento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elemento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementoExists(elemento.Id))
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
            return View(elemento);
        }

        // GET: Elemento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elementos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }

        // POST: Elemento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento != null)
            {
                _context.Elementos.Remove(elemento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementoExists(int id)
        {
            return _context.Elementos.Any(e => e.Id == id);
        }
    }
}
