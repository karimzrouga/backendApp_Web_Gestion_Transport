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
    public class ListePlanificationsController : ControllerBase
    {
        private readonly PfeContext _context;

        public ListePlanificationsController(PfeContext context)
        {
            _context = context;
        }

        // GET: api/ListePlanifications
        [HttpGet]
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
        public async Task<IActionResult> PutListePlanification(int id, ListePlanification listePlanification)
        {
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
       /* [HttpPost("PostChauffeur")]
        public async Task<ActionResult<Chauffeur>> PostChauffeur(Chauffeur chauffeur)
        {
            if (string.IsNullOrEmpty(chauffeur.Agence))
            {
                return BadRequest("Chauffeur property is required.");
            }


            var agence = await _context.Agences.FirstOrDefaultAsync(a => a.Nom == chauffeur.Agence);
            if (agence == null)
            {
                return BadRequest("Chauffeur not found.");
            }

            chauffeur.AgenceNavigation = agence;
            _context.Chauffeurs.Add(chauffeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChauffeur", new { id = chauffeur.Id }, chauffeur);
        }*/
        // POST: api/ListePlanifications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<User>> PostListePlanification(ListePlanification listePlanification , int iduser)
        {
          if (_context.ListePlanifications == null)
          {
              return Problem("Entity set 'PfeContext.ListePlanifications'  is null.");
          }
            var user =await _context.Users.FindAsync(iduser);
           // return user;
            if (user != null)
            {
                listePlanification.Users.Add(user);
              
                _context.ListePlanifications.Add(listePlanification);
             
               await _context.SaveChangesAsync();


                return CreatedAtAction("GetListePlanification", new { id = listePlanification.Id }, listePlanification);
            }
            else
            {
                return Problem("Entity user'  is null.");
            }
           
        }

        // DELETE: api/ListePlanifications/5
        [HttpDelete("{id}")]
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
