using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

public class PedidoController : Controller
{
    private readonly SQLInventarioPruebaContext _context;

    public PedidoController(SQLInventarioPruebaContext context)
    {
        _context = context;
    }

    // GET: Pedido
    public async Task<IActionResult> Index()
    {
        var sQLInventarioPruebaContext = _context.Pedido.Include(p => p.Cliente);
        return View(await sQLInventarioPruebaContext.ToListAsync());
    }

    // GET: Pedido/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedido = await _context.Pedido
            .Include(p => p.Cliente)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pedido == null)
        {
            return NotFound();
        }

        return View(pedido);
    }

    // GET: Pedido/Create
    public IActionResult Create()
    {
        ViewData["ClienteId"] = _context.Cliente
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre + " " + c.Apellido
            }).ToList();

        return View();
    }

    // POST: Pedido/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FechaPedido,Total,Estado,ClienteId")] Pedido pedido)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["ClienteId"] = _context.Cliente
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre + " " + c.Apellido
            }).ToList();

        return View(pedido);
    }

    // GET: Pedido/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedido = await _context.Pedido.FindAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }

        ViewData["ClienteId"] = _context.Cliente
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre + " " + c.Apellido
            }).ToList();

        return View(pedido);
    }

    // POST: Pedido/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FechaPedido,Total,Estado,ClienteId")] Pedido pedido)
    {
        if (id != pedido.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pedido);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(pedido.Id))
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

        ViewData["ClienteId"] = _context.Cliente
            .Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nombre + " " + c.Apellido
            }).ToList();

        return View(pedido);
    }

    // GET: Pedido/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pedido = await _context.Pedido
            .Include(p => p.Cliente)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pedido == null)
        {
            return NotFound();
        }

        return View(pedido);
    }

    // POST: Pedido/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pedido = await _context.Pedido.FindAsync(id);
        if (pedido != null)
        {
            _context.Pedido.Remove(pedido);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PedidoExists(int id)
    {
        return _context.Pedido.Any(e => e.Id == id);
    }
}
