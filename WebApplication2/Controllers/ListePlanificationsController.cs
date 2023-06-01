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
    public class ListePlanificationsController : ControllerBase
    {
        private readonly PfeContext _context;

        public ListePlanificationsController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/ListePlanifications
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ListePlanification>>> GetListePlanifications()
        {
          if (_context.ListePlanifications == null)
          {
              return NotFound();
          }
            return await _context.ListePlanifications.Include(e => e.Users).ToListAsync();
        }

        // GET: api/ListePlanifications/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ListePlanification>> GetListePlanification(int id)
        {
          if (_context.ListePlanifications == null)
          {
              return NotFound();
          }
            var listePlanification = await _context.ListePlanifications.Include(e => e.Users).FirstOrDefaultAsync(e => e.Id == id);

            if (listePlanification == null)
            {
                return NotFound();
            }

            return listePlanification;
        }

        // PUT: api/ListePlanifications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutListePlanification(int id, ListePlanification listePlanification)
        {
            listePlanification.UpdatedAt = DateTime.Now;
            if (id != listePlanification.Id)
            {
                return BadRequest();
            }

            _context.Entry(listePlanification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListePlanificationExists(id))
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
      
        // POST: api/ListePlanifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> PostListePlanification(ListePlanification listePlanification )
        {
          if (_context.ListePlanifications == null)
          {
              return Problem("Entity set 'PfeContext.ListePlanifications'  is null.");
          }
            
            
                _context.ListePlanifications.Add(listePlanification);
             
               await _context.SaveChangesAsync();


                return CreatedAtAction("GetListePlanification", new { id = listePlanification.Id }, listePlanification);
            

           
        }

        // DELETE: api/ListePlanifications/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteListePlanification(int id)
        {
            if (_context.ListePlanifications == null)
            {
                return NotFound();
            }
            var listePlanification = await _context.ListePlanifications.FindAsync(id);
            if (listePlanification == null)
            {
                return NotFound();
            }

            _context.ListePlanifications.Remove(listePlanification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListePlanificationExists(int id)
        {
            return (_context.ListePlanifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
