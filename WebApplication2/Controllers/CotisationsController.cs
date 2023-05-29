using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestpsfe.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotisationsController : ControllerBase
    {
        private readonly PfeContext _context;

        public CotisationsController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/Cotisations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cotisation>>> GetCotisations()
        {
          if (_context.Cotisations == null)
          {
              return NotFound();
          }
            return await _context.Cotisations.ToListAsync();
        }

        // GET: api/Cotisations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cotisation>> GetCotisation(int id)
        {
          if (_context.Cotisations == null)
          {
              return NotFound();
          }
            var cotisation = await _context.Cotisations.FindAsync(id);

            if (cotisation == null)
            {
                return NotFound();
            }

            return cotisation;
        }

        // PUT: api/Cotisations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotisation(int id, Cotisation cotisation)
        {
            if (id != cotisation.Id)
            {
                return BadRequest();
            }

            _context.Entry(cotisation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CotisationExists(id))
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

        // POST: api/Cotisations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cotisation>> PostCotisation(Cotisation cotisation)
        {
          if (_context.Cotisations == null)
          {
              return Problem("Entity set 'PfeContext.Cotisations'  is null.");
          }
            _context.Cotisations.Add(cotisation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCotisation", new { id = cotisation.Id }, cotisation);
        }

        // DELETE: api/Cotisations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotisation(int id)
        {
            if (_context.Cotisations == null)
            {
                return NotFound();
            }
            var cotisation = await _context.Cotisations.FindAsync(id);
            if (cotisation == null)
            {
                return NotFound();
            }

            _context.Cotisations.Remove(cotisation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CotisationExists(int id)
        {
            return (_context.Cotisations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
