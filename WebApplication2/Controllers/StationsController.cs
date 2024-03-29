﻿using System;
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
    public class StationsController : ControllerBase
    {
        private readonly PfeContext _context;

        public StationsController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/Stations
         //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Station>>> GetStations()
        {
          if (_context.Stations == null)
          {
              return NotFound();
          }
            return await _context.Stations.Include(e => e.Vehicules).Include(e => e.Circuits).Include(e => e.Users).ToListAsync();
        }



        // GET: api/addstation/5/1
         //[Authorize]
        [HttpGet("{id}/{idcircuit}")]
        public async Task<ActionResult<Vehicule>> addstation(int id, int idcircuit)
        {
            if (_context.Vehicules == null)
            {
                return NotFound();
            }
            var station = await _context.Stations.FindAsync(id);
            var circuit = await _context.Circuits.FindAsync(idcircuit);

            if (station == null | circuit == null)
            {
                return NotFound();
            }

            station.Circuits.Add(circuit);

            _context.Entry(circuit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // GET: api/Stations/5
         //[Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Station>> GetStation(int id)
        {
          if (_context.Stations == null)
          {
              return NotFound();
          }
            var station = await _context.Stations.Include(e => e.Vehicules).Include(e => e.Circuits)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (station == null)
            {
                return NotFound();
            }

            return station;
        }

        // PUT: api/Stations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStation(int id, Station station)
        {
            station.UpdatedAt = DateTime.Now;
            if (id != station.Id)
            {
                return BadRequest();
            }

            _context.Entry(station).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // POST: api/Stations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         //[Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult<Station>> PostStation(Station station , int id)
        {
            if (_context.Circuits == null)
            {
                return Problem("Entity set 'PfeContext.Circuits'  is null.");
            }

            if (_context.Stations == null)
          {
              return Problem("Entity set 'PfeContext.Stations'  is null.");
          }
           var c = await _context.Circuits.FirstOrDefaultAsync(e => e.Id == id);
            station.Circuits.Add(c);
            _context.Stations.Add(station);
            await _context.SaveChangesAsync();

            



            return CreatedAtAction("GetStation", new { id = station.Id }, station);
        }

        // DELETE: api/Stations/5
         //[Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(int id)
        {
            if (_context.Stations == null)
            {
                return NotFound();
            }
            var station = await _context.Stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StationExists(int id)
        {
            return (_context.Stations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
