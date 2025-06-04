using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoApiController : ControllerBase
    {
        private readonly SQLServerContextGestionInventarioSJCP _context;

        public PedidoApiController(SQLServerContextGestionInventarioSJCP context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetAll() =>
            await _context.Pedido.Include(p => p.Cliente).ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            var pedido = await _context.Pedido.Include(p => p.Cliente)
                                              .FirstOrDefaultAsync(p => p.Id == id);
            return pedido == null ? NotFound() : Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Create(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest();
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null) return NotFound();
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
