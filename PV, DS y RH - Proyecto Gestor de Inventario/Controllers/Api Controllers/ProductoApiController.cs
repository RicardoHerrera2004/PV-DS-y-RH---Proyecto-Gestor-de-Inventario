using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoApiController : ControllerBase
    {
        private readonly SQLServerContextGestionInventarioSJCP _context;

        public ProductoApiController(SQLServerContextGestionInventarioSJCP context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            return await _context.Producto.Include(p => p.Categoria).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var producto = await _context.Producto.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            if (producto == null)
                return NotFound();
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Create(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest();

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Producto.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
                return NotFound();

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
