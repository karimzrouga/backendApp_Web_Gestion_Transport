using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestpsfe.Models;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculesController : ControllerBase
    {
        private readonly PfeContext _context;

        public VehiculesController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/Vehicules
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicule>>> GetVehicules()
        {
          if (_context.Vehicules == null)
          {
              return NotFound();
          }
            return await _context.Vehicules.Include(e=>e.Stations).ToListAsync();
        }



        // GET: api/addstation/5/1
        [Authorize]
        [HttpGet("{id}/{idstat}")]
        public async Task<ActionResult<Vehicule>> addstation(int id, int idstat)
        {
            if (_context.Vehicules == null)
            {
                return NotFound();
            }
            var vehicule = await _context.Vehicules.FindAsync(id);
            var station = await _context.Stations.FindAsync(idstat);
          
            if (vehicule == null |station==null)
            {
                return NotFound();
            }
            if(vehicule.Stations.Contains(station))
                    {
                return Problem("Alderly Existe");
            }
            vehicule.Stations.Add(station);

            _context.Entry(vehicule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeExists(id))
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



        // GET: api/Vehicules/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicule>> GetVehicule(int id)
        {
          if (_context.Vehicules == null)
          {
              return NotFound();
          }
            var vehicule = await _context.Vehicules.Include(e => e.Stations)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (vehicule == null)
            {
                return NotFound();
            }

            return vehicule;
        }

        // PUT: api/Vehicules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicule(int id, Vehicule vehicule)
        {
            vehicule.UpdatedAt = DateTime.Now;
            if (id != vehicule.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculeExists(id))
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

        // POST: api/Vehicules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Vehicule>> PostVehicule(Vehicule vehicule)
        {
          if (_context.Vehicules == null)
          {
              return Problem("Entity set 'PfeContext.Vehicules'  is null.");
          }
            _context.Vehicules.Add(vehicule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicule", new { id = vehicule.Id }, vehicule);
        }

        // DELETE: api/Vehicules/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicule(int id)
        {
            if (_context.Vehicules == null)
            {
                return NotFound();
            }
            var vehicule = await _context.Vehicules.FindAsync(id);
            if (vehicule == null)
            {
                return NotFound();
            }

            _context.Vehicules.Remove(vehicule);
            await _context.SaveChangesAsync();
            return Ok("Deleted");
        }

        private bool VehiculeExists(int id)
        {
            return (_context.Vehicules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
