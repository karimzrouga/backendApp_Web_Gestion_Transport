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
    public class CircuitsController : ControllerBase
    {
        private readonly PfeContext _context;

        public CircuitsController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/Circuits
        [HttpGet]
           //[Authorize]
        public async Task<ActionResult<IEnumerable<Circuit>>> GetCircuits()
        {
          if (_context.Circuits == null)
          {
              return NotFound();
          }
            return await _context.Circuits.Include(e => e.Stations).Include(e => e.Shifts).ToListAsync();
        }

        // GET: api/Circuits/5
        [HttpGet("{id}")]
           //[Authorize]
        public async Task<ActionResult<Circuit>> GetCircuit(int id)
        {
          if (_context.Circuits == null)
          {
              return NotFound();
          }
            var circuit = await _context.Circuits.Include(e => e.Stations).FirstOrDefaultAsync(e => e.Id == id);

            if (circuit == null)
            {
                return NotFound();
            }

            return circuit;
        }

        // PUT: api/Circuits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
           //[Authorize]
        public async Task<IActionResult> PutCircuit(int id, Circuit circuit)
        {
            circuit.UpdatedAt = DateTime.Now;
            if (id != circuit.Id)
            {
                return BadRequest();
            }

            _context.Entry(circuit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitExists(id))
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

        // POST: api/Circuits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
           //[Authorize]
        public async Task<ActionResult<Circuit>> PostCircuit(Circuit circuit)
        {
          if (_context.Circuits == null)
          {
              return Problem("Entity set 'PfeContext.Circuits'  is null.");
          }
            _context.Circuits.Add(circuit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCircuit", new { id = circuit.Id }, circuit);
        }

        // DELETE: api/Circuits/5
        [HttpDelete("{id}")]
           //[Authorize]
        public async Task<IActionResult> DeleteCircuit(int id)
        {
            if (_context.Circuits == null)
            {
                return NotFound();
            }
            var circuit = await _context.Circuits.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }

            _context.Circuits.Remove(circuit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CircuitExists(int id)
        {
            return (_context.Circuits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
