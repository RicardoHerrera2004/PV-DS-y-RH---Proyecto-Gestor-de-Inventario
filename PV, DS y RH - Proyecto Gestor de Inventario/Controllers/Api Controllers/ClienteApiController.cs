using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Models;

namespace PV__DS_y_RH___Proyecto_Gestor_de_Inventario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteApiController : ControllerBase
    {
        private readonly SQLServerContextGestionInventarioSJCP _context;

        public ClienteApiController(SQLServerContextGestionInventarioSJCP context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll() =>
            await _context.Cliente.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null) return NotFound();
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
