using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Controllers
{
    public class DetallePedidoController : Controller
    {
        private readonly SQLInventarioPruebaContext _context;

        public DetallePedidoController(SQLInventarioPruebaContext context)
        {
            _context = context;
        }

        // GET: DetallePedido
        public async Task<IActionResult> Index()
        {
            var sQLInventarioPruebaContext = _context.DetallePedido.Include(d => d.Pedido).Include(d => d.Producto);
            return View(await sQLInventarioPruebaContext.ToListAsync());
        }

        // GET: DetallePedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedido/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre");
            return View();
        }

        // POST: DetallePedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrecioOriginal,PrecioVendido,Obervacion,PedidoId,ProductoId")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "Id", "Id", detallePedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre", detallePedido.ProductoId);
            return View(detallePedido);
        }

        // GET: DetallePedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "Id", "Id", detallePedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre", detallePedido.ProductoId);
            return View(detallePedido);
        }

        // POST: DetallePedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecioOriginal,PrecioVendido,Obervacion,PedidoId,ProductoId")] DetallePedido detallePedido)
        {
            if (id != detallePedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedido>(), "Id", "Id", detallePedido.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre", detallePedido.ProductoId);
            return View(detallePedido);
        }

        // GET: DetallePedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido != null)
            {
                _context.DetallePedido.Remove(detallePedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.Id == id);
        }
    }
}
