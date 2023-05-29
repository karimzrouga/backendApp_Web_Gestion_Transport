﻿using System;
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
    public class AgencesController : ControllerBase
    {
        private readonly PfeContext _context;

        public AgencesController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/Agences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agence>>> GetAgences()
        {
          if (_context.Agences == null)
          {
              return NotFound();
          }
            return await _context.Agences.ToListAsync();
        }

        // GET: api/Agences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agence>> GetAgence(int id)
        {
          if (_context.Agences == null)
          {
              return NotFound();
          }
            var agence = await _context.Agences.FindAsync(id);

            if (agence == null)
            {
                return NotFound();
            }

            return agence;
        }

        // PUT: api/Agences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgence(int id, Agence agence)
        {
            if (id != agence.Id)
            {
                return BadRequest();
            }

            _context.Entry(agence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenceExists(id))
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

        // POST: api/Agences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Agence>> PostAgence(Agence agence)
        {
          if (_context.Agences == null)
          {
              return Problem("Entity set 'PfeContext.Agences'  is null.");
          }
            _context.Agences.Add(agence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgence", new { id = agence.Id }, agence);
        }

        // DELETE: api/Agences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgence(int id)
        {
            if (_context.Agences == null)
            {
                return NotFound();
            }
            var agence = await _context.Agences.FindAsync(id);
            if (agence == null)
            {
                return NotFound();
            }

            _context.Agences.Remove(agence);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenceExists(int id)
        {
            return (_context.Agences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
