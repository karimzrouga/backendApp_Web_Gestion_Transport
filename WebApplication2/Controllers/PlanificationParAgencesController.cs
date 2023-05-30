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
    public class PlanificationParAgencesController : ControllerBase
    {
        private readonly PfeContext _context;

        public PlanificationParAgencesController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/PlanificationParAgences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanificationParAgence>>> GetPlanificationParAgences()
        {
          if (_context.PlanificationParAgences == null)
          {
              return NotFound();
          }
            return await _context.PlanificationParAgences.ToListAsync();
        }

        // GET: api/PlanificationParAgences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanificationParAgence>> GetPlanificationParAgence(int id)
        {
          if (_context.PlanificationParAgences == null)
          {
              return NotFound();
          }
            var planificationParAgence = await _context.PlanificationParAgences.FindAsync(id);

            if (planificationParAgence == null)
            {
                return NotFound();
            }

            return planificationParAgence;
        }

        // PUT: api/PlanificationParAgences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanificationParAgence(int id, PlanificationParAgence planificationParAgence)
        {
            if (id != planificationParAgence.Id)
            {
                return BadRequest();
            }

            _context.Entry(planificationParAgence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanificationParAgenceExists(id))
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

        // POST: api/PlanificationParAgences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanificationParAgence>> PostPlanificationParAgence(PlanificationParAgence planificationParAgence)
        {
          if (_context.PlanificationParAgences == null)
          {
              return Problem("Entity set 'PfeContext.PlanificationParAgences'  is null.");
          }
            _context.PlanificationParAgences.Add(planificationParAgence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanificationParAgence", new { id = planificationParAgence.Id }, planificationParAgence);
        }

        // DELETE: api/PlanificationParAgences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanificationParAgence(int id)
        {
            if (_context.PlanificationParAgences == null)
            {
                return NotFound();
            }
            var planificationParAgence = await _context.PlanificationParAgences.FindAsync(id);
            if (planificationParAgence == null)
            {
                return NotFound();
            }

            _context.PlanificationParAgences.Remove(planificationParAgence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanificationParAgenceExists(int id)
        {
            return (_context.PlanificationParAgences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
