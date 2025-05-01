using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly SQLServerContextGestionInventarioSJCP _context;

        public CategoriaController(SQLServerContextGestionInventarioSJCP context)
        {
            _context = context;
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoria.ToListAsync());
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.Id))
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
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var cat = await _context.Categoria
                                    .Include(c => c.Productos)
                                    .FirstOrDefaultAsync(c => c.Id == id);
            if (cat == null) return NotFound();

            if (cat.Productos.Any())
            {
                // Le pasamos a la vista un aviso
                ViewBag.ErrorMessage =
                    $"No puedes eliminar la categoría «{cat.Nombre}» porque tiene {cat.Productos.Count} producto(s) asociados.";
            }
            return View(cat);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cat = await _context.Categoria
                             .Include(c => c.Productos)
                             .FirstOrDefaultAsync(c => c.Id == id);

            if (cat.Productos.Any())
            {
                // Re-renderiza la vista con el mensaje de error
                ViewBag.ErrorMessage =
                    $"No puedes eliminar «{cat.Nombre}» porque hay {cat.Productos.Count} productos asociados.";
                return View(cat);
            }

            _context.Categoria.Remove(cat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
