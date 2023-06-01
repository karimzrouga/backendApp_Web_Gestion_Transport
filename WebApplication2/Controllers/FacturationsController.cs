using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestpsfe.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturationsController : ControllerBase
    {
        private readonly PfeContext _context;

        public FacturationsController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/Facturations
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Facturation>>> GetFacturations()
        {
          if (_context.Facturations == null)
          {
              return NotFound();
          }
            return await _context.Facturations.ToListAsync();
        }

        // GET: api/Facturations/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Facturation>> GetFacturation(int id)
        {
          if (_context.Facturations == null)
          {
              return NotFound();
          }
            var facturation = await _context.Facturations.FindAsync(id);

            if (facturation == null)
            {
                return NotFound();
            }

            return facturation;
        }

        // PUT: api/Facturations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFacturation(int id, Facturation facturation)
        {
            facturation.UpdatedAt = DateTime.Now;
            if (id != facturation.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Facturations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Facturation>> PostFacturation(Facturation facturation)
        {
          if (_context.Facturations == null)
          {
              return Problem("Entity set 'PfeContext.Facturations'  is null.");
          }
            _context.Facturations.Add(facturation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturation", new { id = facturation.Id }, facturation);
        }

        // DELETE: api/Facturations/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFacturation(int id)
        {
            if (_context.Facturations == null)
            {
                return NotFound();
            }
            var facturation = await _context.Facturations.FindAsync(id);
            if (facturation == null)
            {
                return NotFound();
            }

            _context.Facturations.Remove(facturation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturationExists(int id)
        {
            return (_context.Facturations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
